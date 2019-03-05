using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common.utils
{
    public class SerializeUtil
    {
        public static string Serialize(object obj,Type type)
        {
            string result = null;
            using (MemoryStream stream1 = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(type);
                ser.WriteObject(stream1, obj);
                stream1.Position = 0;
                using (StreamReader sr = new StreamReader(stream1))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        public static T Deserialize<T>(string json, Type type)
        {
            T result = default(T);
            byte[] buffer = Encoding.Default.GetBytes(json);
            using (MemoryStream stream1 = new MemoryStream(buffer))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(type);
                stream1.Position = 0;
                result = (T)ser.ReadObject(stream1);
            }
            return result;
        } 
    }
}
