using System.ComponentModel;
namespace Common.http.response
{
    public enum StatusCodeEnum
    {
        [Description("正常")]
        OK = 0,
        [Description("请求参数非法")]
        ParameterInvalid = 2,
        [Description("权限校验失败")]
        VerifyFailure = 3,
        [Description("配额校验失败")]
        QuotaFailure = 4,
        [Description("ak不存在或者非法")]
        AKFailure = 5
    }
}
