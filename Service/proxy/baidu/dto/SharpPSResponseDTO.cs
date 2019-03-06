using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class SharpPSResponseDTO
    {
        public SharpPSResponseDTO() { }
        private string name;
        private Location location;
        private string address;
        private string province;
        private string city;
        private string area;
        private string street_id;
        private int detail;
        private string uid;

        public string Name { get => name; set => name = value; }
        public Location Location { get => location; set => location = value; }
        public string Address { get => address; set => address = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }
        public string Area { get => area; set => area = value; }
        public string Street_id { get => street_id; set => street_id = value; }
        public int Detail { get => detail; set => detail = value; }
        public string Uid { get => uid; set => uid = value; }
    }
}
