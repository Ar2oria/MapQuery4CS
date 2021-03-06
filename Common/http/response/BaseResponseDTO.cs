﻿using System;
using System.Runtime.Serialization;
using Common.http.response;

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
        private int total;
        [DataMember]
        private T results = default(T);

        public BaseResponseDTO() { }

        public int Status { get => status; set => status = value; }
        public T Results { get => results; set => results = value; }
        public string Message { get => message; set => message = value; }
        public int Total { get => total; set => total = value; }
    }
}
