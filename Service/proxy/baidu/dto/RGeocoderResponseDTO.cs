using Common.http.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class RGeocoderResponseDTO : BaseDTO
    {
        public RGeocoderResponseDTO() { }
        /**
         * （注意，国外行政区划，字段仅代表层级）
         */
        private AddressComponent addressComponent;
        /**
         * 经纬度坐标
         */
        private Location location;
        /**
         * 坐标所在商圈信息，如 "人民大学,中关村,苏州街"。最多返回3个。
         */
        private string business;
        /**
         * 百度定义的城市id
         */
        private int cityCode;
        /**
         * 结构化地址信息
         */
        private string formatted_address;

        private string sematic_description;

        private List<Poi> pois;

        private List<PoiRegion> poiRegions;

        public AddressComponent AddressComponent { get => addressComponent; set => addressComponent = value; }
        public Location Location { get => location; set => location = value; }
        public string Business { get => business; set => business = value; }
        public int CityCode { get => cityCode; set => cityCode = value; }
        public string Formatted_address { get => formatted_address; set => formatted_address = value; }
        public List<Poi> Pois { get => pois; set => pois = value; }
        public List<PoiRegion> PoiRegions { get => poiRegions; set => poiRegions = value; }
        public string Sematic_description { get => sematic_description; set => sematic_description = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class AddressComponent : BaseDTO
    {
        public AddressComponent() { }

        /**
         * 国家
         */
        private string country;
        /**
         * 省名
         */
        private string province;
        /**
         * 城市名
         */
        private string city;
        /**
         * 区县名
         */
        private string district;
        /**
         * 乡镇名
         */
        private string town;
        /**
         * 街道名（行政区划中的街道层级）
         */
        private string street;
        /**
         * 街道门牌号
         */
        private string street_number;
        /**
         * 行政区划代码 adcode映射表
         */
        private string adcode;
        /**
         * 国家代码
         */
        private int country_code;
        /**
         * 相对当前坐标点的方向，当有门牌号的时候返回数据
         */
        private string direction;
        /**
         * 相对当前坐标点的距离，当有门牌号的时候返回数据
         */
        private string distance;

        private int city_level;
        private string country_code_iso;
        private string country_code_iso2;

        public string Country { get => country; set => country = value; }
        public string Province { get => province; set => province = value; }
        public string City { get => city; set => city = value; }
        public string District { get => district; set => district = value; }
        public string Town { get => town; set => town = value; }
        public string Street { get => street; set => street = value; }
        public string Street_number { get => street_number; set => street_number = value; }
        public string Adcode { get => adcode; set => adcode = value; }
        public int Country_code { get => country_code; set => country_code = value; }
        public string Direction { get => direction; set => direction = value; }
        public string Distance { get => distance; set => distance = value; }
        public int City_level { get => city_level; set => city_level = value; }
        public string Country_code_iso { get => country_code_iso; set => country_code_iso = value; }
        public string Country_code_iso2 { get => country_code_iso2; set => country_code_iso2 = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Poi:BaseDTO
    {
        public Poi() { }
        private string addr;
        private string cp;
        private string direction;
        private string distance;
        private string name;
        private string tag;
        private Point point;
        private string poiType;
        private string tel;
        private string uid;
        private string zip;
        private Poi parent_poi;

        public string Addr { get => addr; set => addr = value; }
        public string Cp { get => cp; set => cp = value; }
        public string Direction { get => direction; set => direction = value; }
        public string Distance { get => distance; set => distance = value; }
        public string Name { get => name; set => name = value; }
        public string Tag { get => tag; set => tag = value; }
        public Point Point { get => point; set => point = value; }
        public string PoiType { get => poiType; set => poiType = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Uid { get => uid; set => uid = value; }
        public string Zip { get => zip; set => zip = value; }
        public Poi Parent_poi { get => parent_poi; set => parent_poi = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class PoiRegion:BaseDTO
    {
        public PoiRegion() { }
        private string direction_desc;
        private string name;
        private string tag;
        private string uid;

        public string Direction_desc { get => direction_desc; set => direction_desc = value; }
        public string Name { get => name; set => name = value; }
        public string Tag { get => tag; set => tag = value; }
        public string Uid { get => uid; set => uid = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class Point:BaseDTO
    {
        public Point() { }

        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}
