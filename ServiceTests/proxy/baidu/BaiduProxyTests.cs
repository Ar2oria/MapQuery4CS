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
            placeSearchRequestDTO.Region = "北京";
            placeSearchRequestDTO.Output = "json";
            var result = BaiduProxy.PlaceSearch(placeSearchRequestDTO);
        }
    }
}