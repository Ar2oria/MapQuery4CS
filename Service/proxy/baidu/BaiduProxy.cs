using Common.http;
using Common.http.response;
using Common.utils;
using Service.Properties;
using Service.proxy.baidu.dto;
using System.Collections.Generic;

namespace Service.proxy.baidu
{
    public class BaiduProxy
    {
        public static List<PlaceSearchResponseDTO> PlaceSearch(PlaceSearchRequestDTO placeSearchRequestDTO)
        {
            if (placeSearchRequestDTO.Query == null || placeSearchRequestDTO.Query.Trim()=="")
            {
                throw new System.Exception("Query必须不能为空值！");
            }
            return BaseProxy.DoGetWithAutoDeserilize<PlaceSearchRequestDTO, List<PlaceSearchResponseDTO>>(Resources.BaiduMapPlaceSearch, placeSearchRequestDTO);
        }

        public static List<SharpPSResponseDTO> RectanglePlaceSearch(PlaceSearchRequestDTO placeSearchRequestDTO)
        {
            if (placeSearchRequestDTO.Bounds == null)
            {
                throw new System.Exception("Bounds必须不能为空值！");
            }
            return BaseProxy.DoGetWithAutoDeserilize<PlaceSearchRequestDTO, List<SharpPSResponseDTO>>(Resources.BaiduMapPlaceSearch, placeSearchRequestDTO);
        }

        public static List<SharpPSResponseDTO> CirclePlaceSearch(PlaceSearchRequestDTO placeSearchRequestDTO)
        {
            if (placeSearchRequestDTO.Location == null)
            {
                throw new System.Exception("Location必须不能为空值！");
            }
            return BaseProxy.DoGetWithAutoDeserilize<PlaceSearchRequestDTO, List<SharpPSResponseDTO>>(Resources.BaiduMapPlaceSearch, placeSearchRequestDTO);
        }

        public static LGeocoderResponseDTO LGeocoder(LGeocoderRequestDTO lGeocoderRequestDTO)
        {
            SingleResponseDTO<LGeocoderResponseDTO> obj = (SingleResponseDTO<LGeocoderResponseDTO>)BaseProxy.DoGetWithDeserilizeManual(Resources.BaiduMapGeocoder, lGeocoderRequestDTO, typeof(SingleResponseDTO<LGeocoderResponseDTO>));
            if (obj == null || obj.Result == null)
            {
                if (obj.Status != 1)
                {
                    throw new System.Exception("LGeocoderResponseDTO函数====>解析异常！，请求参数" + lGeocoderRequestDTO.ToString());
                }

            }
            return obj.Result;
        }

        public static RGeocoderResponseDTO RGeocoder(RGeocoderRequestDTO rGeocoderRequestDTO)
        {
            SingleResponseDTO<RGeocoderResponseDTO> obj = (SingleResponseDTO<RGeocoderResponseDTO>)BaseProxy.DoGetWithDeserilizeManual(Resources.BaiduMapGeocoder, rGeocoderRequestDTO, typeof(SingleResponseDTO<RGeocoderResponseDTO>));
            if (obj == null || obj.Result == null)
            {
                throw new System.Exception("RGeocoderResponseDTO函数====>解析异常！，请求参数" + rGeocoderRequestDTO.ToString());
            }
            return obj.Result;
        }

       public static IPConvertResponseDTO IPConvert(IPConvertRequestDTO iPConvertRequestDTO)
        {
            IPConvertResponseDTO obj = (IPConvertResponseDTO)BaseProxy.DoGetWithDeserilizeManual<IPConvertRequestDTO>(Resources.BaiduMapIPConvert, iPConvertRequestDTO, typeof(IPConvertResponseDTO));
            if (obj == null)
            {
                throw new System.Exception("IPConvertResponseDTO函数异常====>解析异常！，请求参数" + iPConvertRequestDTO.ToString());
            }
            return obj;
        }


    }
}
