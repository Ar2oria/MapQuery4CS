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
            Assert.Fail();
        }
    }
}