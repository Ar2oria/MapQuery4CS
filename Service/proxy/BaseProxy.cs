using Common.http;
using Common.http.request;
using Common.http.response;
using Common.utils;
using Newtonsoft.Json;
using Service.common;
using Service.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy
{
    public class BaseProxy
    {
        public static string DoGet(string url)
        {
            return DoGet<BaseRequestDTO>(url, new BaseRequestDTO());
        }
        public static string DoGet<T>(string url, T obj) where T : BaseRequestDTO
        {
            Trace.TraceInformation("DoGet方法====>请求url={0},请求参数={1}", url, obj.ToString());
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var sn = AKSNCaculater.CaculateAKSN(Resources.MyAk, Resources.MySk, url, obj);
            var param = obj.ToString() + "&ak=" + Resources.MyAk + "&sn=" + sn;
            Trace.TraceInformation("DoGet方法====>请求地址={0}", param);
            var result = HttpRequestUtil.GetHttpResponse(Resources.BaiduMapBaseUrl + url + "?" + param, 3000);
            stopwatch.Stop();
            Trace.TraceInformation("DoGet方法====>耗时={0}毫秒,请求地址={1},返回结果={2}", stopwatch.ElapsedMilliseconds.ToString(), param, result);
            return result;
        }

        public static object DoGetWithDeserilizeManual<T>(string url, T obj, Type type) where T : BaseRequestDTO
        {
            var response = DoGet<T>(url, obj);
            if (response == null)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>网络请求异常，请检查网络，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("网络请求异常，请检查网络！");
            }
            object result = null;
            try
            {
                result = JsonConvert.DeserializeObject(response, type);
            }
            catch (Exception exp)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>JsonConvert.DeserializeObject函数异常！,检测参数是否正确，异常信息e={0}，请求url={1},请求参数={2}", exp.Message, url, obj.ToString());
                throw new Exception("JsonConvert.DeserializeObject函数异常！");
            }
            if (result == null)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，检测参数是否正确，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("解析json异常，检测参数是否正确！");
            }
            return result;
        }

        public static F DoGetWithAutoDeserilize<T, F>(string url, T obj) where T : BaseRequestDTO
        {
            var response = DoGet<T>(url, obj);
            if (response == null)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>网络请求异常，请检查网络，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("网络请求异常，请检查网络！");
            }

            BaseResponseDTO<F> result = null;
            try
            {
                result = JsonConvert.DeserializeObject<BaseResponseDTO<F>>(response);
            }
            catch(Exception exp)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>JsonConvert.DeserializeObject函数异常！,检测参数是否正确，异常信息e={0}，请求url={1},请求参数={2}", exp.Message, url, obj.ToString());
                throw new Exception("JsonConvert.DeserializeObject函数异常！");
            }
            if (result == null)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，检测参数是否正确，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("解析json异常，检测参数是否正确！");
            }
            if (result.Status != (int)Common.http.response.StatusCodeEnum.OK)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，检测ak或sn是否正确，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("网络请求状态异常，检测ak或sn是否正确！");
            }
            if (result.Results == null)
            {
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，json为空，请求url={0},请求参数={1}", url, obj.ToString());
                throw new Exception("解析json异常，json为空！");
            }
            return result.Results;

        }
    }
}
