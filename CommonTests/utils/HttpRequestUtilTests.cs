using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.http;
using Service.proxy.baidu.dto;
using Newtonsoft.Json;

namespace Common.utils.Tests
{
    [TestClass()]
    public class HttpRequestUtilTests
    {
        [TestMethod()]
        public void GetHttpResponseTest()
        {
            var response = HttpRequestUtil.GetHttpResponse("http://api.map.baidu.com/place/v2/search?query=ATM%E6%9C%BA&tag=%E9%93%B6%E8%A1%8C&region=%E5%8C%97%E4%BA%AC&output=json&ak=Y1XohU4UQoppPo2eRjmdm9ed72qPwKp9&sn=b115c7a5e533345798210949f39975e0", 3000);

            var obj = JsonConvert.DeserializeObject<BaseResponseDTO<List<PlaceSearchResponseDTO>>>(response);

        }
    }
}