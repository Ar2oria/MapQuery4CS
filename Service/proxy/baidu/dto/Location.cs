using Common.http.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class Location : BaseDTO
    {
        private double lat;

        private double lng;

        public Location() { }

        public double Lat { get => lat; set => lat = value; }
        public double Lng { get => lng; set => lng = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
