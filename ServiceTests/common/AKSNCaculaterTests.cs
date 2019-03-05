using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Properties;
using Service.proxy.baidu.dto;

namespace Service.common.Tests
{
    [TestClass()]
    public class AKSNCaculaterTests
    {
        [TestMethod()]
        public void CaculateAKSNTest()
        {
            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("query", "ATM机");
            param.Add("region", "北京");
            param.Add("output", "json");
            param.Add("coord_type", "1");
            param.Add("city_limit", "False");
            String sn = AKSNCaculater.CaculateAKSN(Resources.MyAk, Resources.MySk, Resources.BaiduMapPlaceSearch, (IDictionary<string,string>)param);

            PlaceSearchRequestDTO dTO = new PlaceSearchRequestDTO();
            dTO.Query = "ATM机";
            dTO.Region = "北京";
            dTO.Output = "json";
            var sn1 = AKSNCaculater.CaculateAKSN<PlaceSearchRequestDTO>(Resources.MyAk, Resources.MySk, Resources.BaiduMapPlaceSearch, dTO);
        }
    }
}