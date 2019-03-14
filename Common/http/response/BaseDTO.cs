using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.http.response
{
    public class BaseDTO
    {
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            var type = this.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var value = item.GetValue(this);
                if (value != null)
                {
                    stringBuilder.Append(item.Name.ToLower() + "=" + value.ToString()+ ",");
                }
            }
            if (properties.Length > 0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
    }
}
