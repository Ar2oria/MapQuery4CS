using System.Runtime.Serialization;

namespace Common.http
{
    [DataContract]
    public class BaseResponseDTO<T>
    {
        [DataMember]
        private int status;
        [DataMember]
        private T result = default(T);

        public BaseResponseDTO() { }
        public BaseResponseDTO(int status, T result)
        {
            this.status = status;
            this.result = result;
        }

        public int Status { get => status; set => status = value; }
        public T Result { get => result; set => result = value; }
    }
}
