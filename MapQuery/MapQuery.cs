using MapQuery.common;
using Service.proxy.baidu;
using Service.proxy.baidu.dto;
using Service.rpc_service;
using Service.rpc_service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MapQuery
{
    public partial class MapQuery : Form
    {
        private IRpcService rpcService = new RpcServiceImpl();
        public MapQuery()
        {
            InitializeComponent();
            //rpcService.InitService();
            //rpcService.JMapQuerySupervisor();
            //LoadStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rpcService.CloseJMapQuery();
            openService.Enabled = true;
            closeService.Enabled = false;
            label1.Text = "服务已关闭.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //rpcService.StartJMapQuery();
            //rpcService.JMapQuerySupervisor();
            openService.Enabled = false;
            closeService.Enabled = true;
            label1.Text = "服务正在启动.";
            LoadStatus();
        }

        private void MapQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpcService.CloseJMapQuery();
        }

        private void LoadStatus()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            new Thread(() =>
            {
                while (true)
                {
                    var status = rpcService.JMapQueryHealthCheck();
                    if (status)
                    {
                        label1.Text = "服务加载完成.";
                        break;
                    }
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Variables.GetPoints(map);
            var radio = Utils.GetFormRadio(groupBox1);

            RGeocoderRequestDTO rGeocoder = new RGeocoderRequestDTO();
            rGeocoder.Location = Variables.CenterY + "," + Variables.CenterX;
            rGeocoder.Ret_coordtype = "gcj02ll";
            rGeocoder.Output = "json";
            var rGeocoderResponseDTO = BaiduProxy.RGeocoder(rGeocoder);


            var searchStr = this.textBox1.Text;
            PlaceSearchRequestDTO place = new PlaceSearchRequestDTO();
            place.Coord_Type = 3;
            place.Ret_Coordtype = "gcj02ll";
            place.Output = "json";

            place.Query = searchStr;

            switch (radio)
            {
                case entity.OptionEnum.auto:
                    if (searchStr==null||searchStr.Trim()=="")
                    {
                        MessageBox.Show("请输入检索词");
                        return;
                    }
                    place.Region = rGeocoderResponseDTO.Formatted_address;
                    var placeSearchResponseDTOs = BaiduProxy.PlaceSearch(place);
                    placeSearchResponseDTOs.ForEach(x => { listBox1.Items.Add(x.ToString()); });
                    break;
                case entity.OptionEnum.rectangle:
                    if (searchStr == null || searchStr.Trim() == "")
                    {
                        MessageBox.Show("请输入检索词");
                        return;
                    }
                    place.Bounds = Variables.LastRectPointY1 + "," + Variables.LastRectPointX1 + "," + Variables.LastRectPointY2 + "," + Variables.LastRectPointX2;
                    var list = BaiduProxy.RectanglePlaceSearch(place);
                    list.ForEach(x => { listBox1.Items.Add(x.ToString()); });
                    break;
                case entity.OptionEnum.circle:
                    if (searchStr == null || searchStr.Trim() == "")
                    {
                        MessageBox.Show("请输入检索词");
                        return;
                    }
                    place.Location = Variables.LastPointY + "," + Variables.LastPointX;
                    place.Radius = Variables.Radius.ToString();
                    var list1 = BaiduProxy.CirclePlaceSearch(place);
                    list1.ForEach(x => { listBox1.Items.Add(x.ToString()); });
                    break;
                case entity.OptionEnum.direction:
                    if (!searchStr.Contains(",") && !searchStr.Contains('，'))
                    {
                        MessageBox.Show("输入格式错误.");
                        return;
                    }

                    var splits = searchStr.Split(new char[] { ',', '，' },StringSplitOptions.RemoveEmptyEntries);
                    if (splits.Length != 2)
                    {
                        MessageBox.Show("输入格式错误.");
                        return;
                    }
                    var dir = splits[0];
                    place.Query = splits[1];
                    place.Location = Variables.LastPointY + "," + Variables.LastPointX;
                    place.Ret_Coordtype = "bd09ll";
                    var list2 = BaiduProxy.CirclePlaceSearch(place);
                    if (dir.Contains("北"))
                    {
                        list2.Where(x => x.Location.Lat > Variables.LastPointY).ToList().ForEach(x => { listBox1.Items.Add(x); });
                    }
                    if (dir.Contains("南"))
                    {
                        list2.Where(x => x.Location.Lat < Variables.LastPointY).ToList().ForEach(x => { listBox1.Items.Add(x); });
                    }
                    if (dir.Contains("西"))
                    {
                        list2.Where(x => x.Location.Lng > Variables.LastPointX).ToList().ForEach(x => { listBox1.Items.Add(x); });
                    }
                    if (dir.Contains("东"))
                    {
                        list2.Where(x => x.Location.Lng < Variables.LastPointX).ToList().ForEach(x => { listBox1.Items.Add(x); });
                    }

                    break;
                case entity.OptionEnum.position:
                    if (searchStr == null || searchStr.Trim() == "")
                    {
                        MessageBox.Show("请输入检索词");
                        return;
                    }
                    LGeocoderRequestDTO lGeocoder = new LGeocoderRequestDTO();
                    lGeocoder.Address = searchStr;
                    lGeocoder.City = rGeocoderResponseDTO.AddressComponent.City;
                    lGeocoder.Ret_coordtype = "gsj02ll";
                    lGeocoder.Output = "json";
                    var lGeocoderResponseDTO = BaiduProxy.LGeocoder(lGeocoder);
                    if (lGeocoderResponseDTO==null)
                    {
                        MessageBox.Show("请检查输入的检索词是否为地理位置");
                        return;
                    }
                    listBox1.Items.Add(lGeocoderResponseDTO);
                    break;
                case entity.OptionEnum.convert:
                    if (searchStr == null || searchStr.Trim() == "")
                    {
                        rGeocoder.Location = Variables.LastPointY + "," + Variables.LastPointX;
                    }
                    else
                    {
                        if (!searchStr.Contains(",")&&!searchStr.Contains("，"))
                        {
                            MessageBox.Show("请确认检索为坐标信息！");
                            return;
                        }
                        rGeocoder.Location = searchStr;
                    }

                    rGeocoder.Pois = 1;
                    rGeocoderResponseDTO = BaiduProxy.RGeocoder(rGeocoder);

                    listBox1.Items.Add(rGeocoderResponseDTO.AddressComponent);
                    listBox1.Items.Add(rGeocoderResponseDTO.Business);
                    listBox1.Items.Add("城市代码：" + rGeocoderResponseDTO.CityCode);
                    listBox1.Items.Add(rGeocoderResponseDTO.Formatted_address);
                    listBox1.Items.Add(rGeocoderResponseDTO.Location);
                    listBox1.Items.Add(rGeocoderResponseDTO.Sematic_description);
                    rGeocoderResponseDTO.Pois.ForEach(x =>
                    {
                        listBox1.Items.Add(x.ToString());
                    });

                    break;
                case entity.OptionEnum.none:
                    break;
            }
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            map.Document.InvokeScript("clearAll");
        }
    }
}
