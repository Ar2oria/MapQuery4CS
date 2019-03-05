using Common.http;
using Common.http.request;
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
        public static string DoGet<T>(string url, T obj) where T:BaseRequestDTO
        {
            Trace.TraceInformation("DoGet方法====>请求url={0},请求参数obj={1}", url, obj.ToString());
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

        public static F DoGetWithAutoDeserilize<T, F>(string url, T obj) where T : BaseRequestDTO where F:BaseResponseDTO<Object>
        {
            var response = DoGet<T>(url, obj);
            if (response == null)
            {
                throw new Exception("网络请求异常，请检查网络！");
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>网络请求异常，请检查网络，请求url={0},请求参数={1}", url, obj.ToString());
            }
            var result = JsonConvert.DeserializeObject<F>(response);
            if (result == null)
            {
                throw new Exception("解析json异常，检测参数是否正确！");
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，检测参数是否正确，请求url={0},请求参数={1}", url, obj.ToString());
            }
            if (result.Status != (int)Common.http.response.StatusCodeEnum.OK)
            {
                throw new Exception("网络请求状态异常，检测ak或sn是否正确！");
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，检测ak或sn是否正确，请求url={0},请求参数={1}", url, obj.ToString());
            }
            if (result.Results == null)
            {
                throw new Exception("解析json异常，json为空！");
                Trace.TraceError("DoGetWithAutoDeserilize方法=====>解析json异常，json为空，请求url={0},请求参数={1}", url, obj.ToString());

            }
            return result;
        }
    }
}
