using Common.http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    [DataContract]
    public class PlaceSearchResponseDTO
    {
        [DataMember]
        private string aaa;
        public PlaceSearchResponseDTO() { }
        public string Aaa { get => aaa; set => aaa = value; }
    }

}
