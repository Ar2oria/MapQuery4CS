using Common.http;
using Common.utils;
using Service.proxy.baidu.dto;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://api.map.baidu.com/geocoder/v2/?address=百度大厦&output=json&ak=yourak&sn=7de5a22212ffaa9e326444c75a58f9a0
            //Dictionary<String, String> param = new Dictionary<string, string>();
            //param.Add("address", "哈尔滨");
            //param.Add("output", "json");
            //param.Add("ak", Resources.MyAk);
            //String sn = AKSNCaculater.CaculateAKSN(Resources.MyAk, Resources.MySk, Resources.BaiduMapGeocoder, param);
            //Console.WriteLine(sn);
            //Console.Read();
            //PlaceSearchRequestDTO placeSearchRequestDTO = new PlaceSearchRequestDTO();
            //placeSearchRequestDTO.Query = "酒店";
            //placeSearchRequestDTO.Region = "北京";

            //Console.WriteLine(placeSearchRequestDTO.ToString());
            //Console.Read();

            //Console.WriteLine(EnumUtil.GetEnumDescription(Common.http.response.StatusCodeEnum.OK));

            BaseResponseDTO<PlaceSearchResponseDTO> baseResponseDTO = new BaseResponseDTO<PlaceSearchResponseDTO>();
            baseResponseDTO.Status = 0;
            baseResponseDTO.Result = new PlaceSearchResponseDTO();
            baseResponseDTO.Result.Aaa = "123";

            var ss = SerializeUtil.Serialize(baseResponseDTO, typeof(BaseResponseDTO<PlaceSearchResponseDTO>));

            var obj = SerializeUtil.Deserialize<BaseResponseDTO<PlaceSearchResponseDTO>>(ss,typeof(BaseResponseDTO<PlaceSearchResponseDTO>));


            Console.Read();
        }
    }
}
