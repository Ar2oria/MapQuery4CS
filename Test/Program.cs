using MapQuery.Properties;
using Service.common;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAKSN();
            //PlaceSearchRequestDTO placeSearchRequestDTO = new PlaceSearchRequestDTO();
            //placeSearchRequestDTO.Query = "酒店";
            //placeSearchRequestDTO.Region = "北京";

            //Console.WriteLine(placeSearchRequestDTO.ToString());
            //Console.Read();

            //Console.WriteLine(EnumUtil.GetEnumDescription(Common.http.response.StatusCodeEnum.OK));

            //BaseResponseDTO<PlaceSearchResponseDTO> baseResponseDTO = new BaseResponseDTO<PlaceSearchResponseDTO>();
            //baseResponseDTO.Status = 0;
            //baseResponseDTO.Result = new PlaceSearchResponseDTO();
            //baseResponseDTO.Result.Aaa = "123";

            //var ss = SerializeUtil.Serialize(baseResponseDTO, typeof(BaseResponseDTO<PlaceSearchResponseDTO>));

            //var obj = SerializeUtil.Deserialize<BaseResponseDTO<PlaceSearchResponseDTO>>(ss,typeof(BaseResponseDTO<PlaceSearchResponseDTO>));


            Console.Read();
        }

        private static void TestAKSN()
        {
            //http://api.map.baidu.com/geocoder/v2/?address=百度大厦&output=json&ak=yourak&sn=7de5a22212ffaa9e326444c75a58f9a0
            Dictionary<String, String> param = new Dictionary<string, string>();
            param.Add("query", "ATM机");
            param.Add("tag", "银行");
            param.Add("region", "北京");
            param.Add("output", "json");
            param.Add("ak", Resources.MyAk);
            String sn = AKSNCaculater.CaculateAKSN(Resources.MyAk, Resources.MySk, Resources.BaiduMapPlaceSearch, param);
            Console.WriteLine(sn);
            Console.Read();
        }
    }
}
