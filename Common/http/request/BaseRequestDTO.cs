using Common.utils;
using System.Text;

namespace Common.http.request
{
    public class BaseRequestDTO
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var type = this.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var value = item.GetValue(this);
                if(value != null)
                {
                    stringBuilder.Append(EncodingUtil.UrlEncode(item.Name.ToLower())+"="+ EncodingUtil.UrlEncode(value.ToString())+"&");
                }
            }

            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}
