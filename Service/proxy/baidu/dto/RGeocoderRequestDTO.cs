using Common.http.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class RGeocoderRequestDTO : BaseRequestDTO
    {
        public RGeocoderRequestDTO() { }

        private string location;
        private string coordtype;
        private string ret_coordtype;
        /**
         * 是否召回传入坐标周边的poi，0为不召回，1为召回。当值为1时，默认显示周边1000米内的poi。
         */
        private int pois = 0;
        private int radius = 1000;
        private string output;

        public string Location { get => location; set => location = value; }
        public string Output { get => output; set => output = value; }
        public string Coordtype { get => coordtype; set => coordtype = value; }
        public string Ret_coordtype { get => ret_coordtype; set => ret_coordtype = value; }
        public int Pois { get => pois; set => pois = value; }
        public int Radius { get => radius; set => radius = value; }

        public override string ToString()
        {
            if (output == null)
            {
                throw new Exception("参数错误，请指定一种输出类型");
            }
            if (location == null)
            {
                throw new Exception("参数错误，location必须不能为空值！");
            }
            return base.ToString();
        }
    }
}
