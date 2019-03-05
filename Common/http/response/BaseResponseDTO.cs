using System.Runtime.Serialization;

namespace Common.http
{
    [DataContract]
    public class BaseResponseDTO<T>
    {
        [DataMember]
        private int status;
        [DataMember]
        private string message;
        [DataMember]
        private T results = default(T);

        public BaseResponseDTO() { }
        public BaseResponseDTO(int status, string message, T results)
        {
            this.status = status;
            this.message = message;
            this.results = results;
        }

        public int Status { get => status; set => status = value; }
        public T Results { get => results; set => results = value; }
        public string Message { get => message; set => message = value; }
    }
}
