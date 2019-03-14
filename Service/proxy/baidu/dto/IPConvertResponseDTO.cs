using Common.http.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class IPConvertResponseDTO : BaseDTO
    {
        public IPConvertResponseDTO() { }
        private string address;
        private int status;
        private Content content;

        public string Address { get => address; set => address = value; }
        public int Status { get => status; set => status = value; }
        public Content Content { get => content; set => content = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Content : BaseDTO
    {
        public Content() { }
        private string address;
        private CPoint point;
        private AddressDetail address_detail;

        public string Address { get => address; set => address = value; }
        public CPoint Point { get => point; set => point = value; }
        public AddressDetail Address_detail { get => address_detail; set => address_detail = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class AddressDetail : BaseDTO
    {
        public AddressDetail() { }
        private string city;
        private int city_code;
        private string district;
        private string province;
        private string street;
        private string street_number;

        public string City { get => city; set => city = value; }
        public int City_code { get => city_code; set => city_code = value; }
        public string District { get => district; set => district = value; }
        public string Province { get => province; set => province = value; }
        public string Street { get => street; set => street = value; }
        public string Street_number { get => street_number; set => street_number = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }


    public class CPoint : BaseDTO
    {
        public CPoint() { }
        private string x;
        private string y;

        public string X { get => x; set => x = value; }
        public string Y { get => y; set => y = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
