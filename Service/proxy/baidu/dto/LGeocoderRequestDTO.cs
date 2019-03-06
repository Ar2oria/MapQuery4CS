using Common.http.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class LGeocoderRequestDTO : BaseRequestDTO
    {
        public LGeocoderRequestDTO() { }
        private string address;
        private string city;
        private string ret_coordtype;
        private string output;

        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Ret_coordtype { get => ret_coordtype; set => ret_coordtype = value; }
        public string Output { get => output; set => output = value; }

        public override string ToString()
        {
            if (output == null)
            {
                throw new Exception("参数错误，请指定一种输出类型");
            }
            if (address == null)
            {
                throw new Exception("地址信息不能为空！");
            }
            return base.ToString();
        }
    }
}
