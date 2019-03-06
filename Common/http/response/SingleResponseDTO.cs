using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.http.response
{
    [DataContract]
    public class SingleResponseDTO<T>
    {
        [DataMember]
        private int status;
        [DataMember]
        private string message;
        [DataMember]
        private T result = default(T);

        public SingleResponseDTO() { }

        public int Status { get => status; set => status = value; }
        public T Result { get => result; set => result = value; }
        public string Message { get => message; set => message = value; }
    }
}
