using Service.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.proxy.baidu.dto;

namespace Service.proxy.Tests
{
    [TestClass()]
    public class BaseProxyyTests
    {
        [TestMethod()]
        public void DoGetTest()
        {
            PlaceSearchRequestDTO place = new PlaceSearchRequestDTO();
            place.Query = "ATM机";
            place.Region = "北京";
            place.Output = "json";
            var response =  BaseProxy.DoGet<PlaceSearchRequestDTO>(Resources.BaiduMapPlaceSearch, place);
        }

        [TestMethod()]
        public void DoGetTest1()
        {
            LGeocoderRequestDTO lGeocoderRequestDTO = new LGeocoderRequestDTO();
            lGeocoderRequestDTO.Address = "哈尔滨理工大学";
            lGeocoderRequestDTO.Output = "json";
            var response = BaseProxy.DoGet<LGeocoderRequestDTO>(Resources.BaiduMapGeocoder, lGeocoderRequestDTO);
        }

        [TestMethod()]
        public void DoGetTest2()
        {
            PlaceSearchRequestDTO place = new PlaceSearchRequestDTO();
            place.Query = "ATM机";
            place.Location = "39.915,116.404";
            place.Output = "json";
            var response = BaseProxy.DoGet<PlaceSearchRequestDTO>(Resources.BaiduMapPlaceSearch, place);
        }

        [TestMethod()]
        public void DoGetTest3()
        {
            PlaceSearchRequestDTO place =   new PlaceSearchRequestDTO();
            place.Query = "ATM机";
            place.Bounds = "39.915,116.404,39.975,116.414";
            place.Output = "json";
            var response = BaseProxy.DoGet<PlaceSearchRequestDTO>(Resources.BaiduMapPlaceSearch, place);
        }

        [TestMethod()]
        public void DoGetTest4()
        {
            RGeocoderRequestDTO rGeocoderRequestDTO = new RGeocoderRequestDTO();
            rGeocoderRequestDTO.Location = "35.658651,139.745415";
            rGeocoderRequestDTO.Output = "json";
            var response = BaseProxy.DoGet<RGeocoderRequestDTO>(Resources.BaiduMapGeocoder, rGeocoderRequestDTO);

        }

    }
}