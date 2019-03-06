using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.proxy.baidu;
using Service.proxy.baidu.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.Tests
{
    [TestClass()]
    public class BaiduProxyTests
    {
        [TestMethod()]
        public void PlaceSearchTest()
        {
            PlaceSearchRequestDTO placeSearchRequestDTO = new PlaceSearchRequestDTO();
            placeSearchRequestDTO.Query = "atm机";
            placeSearchRequestDTO.Region = "哈尔滨理工大学";
            placeSearchRequestDTO.Output = "json";
            var result = BaiduProxy.PlaceSearch(placeSearchRequestDTO);
        }

        [TestMethod()]
        public void LGeocoderTest()
        {
            LGeocoderRequestDTO lGeocoder = new LGeocoderRequestDTO();
            lGeocoder.Address = "黑龙江省哈尔滨市学府路52号哈尔滨理工大学";
            lGeocoder.Output = "json";
            var result = BaiduProxy.LGeocoder(lGeocoder);
        }

        [TestMethod()]
        public void RectanglePS()
        {
            PlaceSearchRequestDTO placeSearchRequestDTO = new PlaceSearchRequestDTO();
            placeSearchRequestDTO.Query = "atm机";
            placeSearchRequestDTO.Bounds = "39.915,116.404,39.975,116.414";
            placeSearchRequestDTO.Output = "json";
            var result = BaiduProxy.RectanglePlaceSearch(placeSearchRequestDTO);

        }

        [TestMethod()]
        public void CirclePS()
        {
            PlaceSearchRequestDTO placeSearchRequestDTO = new PlaceSearchRequestDTO();
            placeSearchRequestDTO.Query = "atm机";
            placeSearchRequestDTO.Location = "39.915,116.404";
            placeSearchRequestDTO.Radius = "2000";
            placeSearchRequestDTO.Output = "json";
            var result = BaiduProxy.CirclePlaceSearch(placeSearchRequestDTO);

        }

        [TestMethod()]
        public void RGeocoderTest()
        {
            RGeocoderRequestDTO rGeocoder = new RGeocoderRequestDTO();
            rGeocoder.Location = "39.915,116.404";
            rGeocoder.Pois = 1;
            rGeocoder.Output = "json";
            var result = BaiduProxy.RGeocoder(rGeocoder);
        }
    }
}