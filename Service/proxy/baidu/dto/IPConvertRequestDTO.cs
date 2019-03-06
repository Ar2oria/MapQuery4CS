using Common.http.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class IPConvertRequestDTO : BaseRequestDTO
    {
        public IPConvertRequestDTO() { }
        private string ip;
        private string coor;

        public string Ip { get => ip; set => ip = value; }
        public string Coor { get => coor; set => coor = value; }
    }
}
