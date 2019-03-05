using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.http.request;
using Service.common;

namespace Service.proxy.baidu.dto
{
    public class PlaceSearchRequestDTO : BaseRequestDTO
    {
        //检索关键字。行政区划区域检索不支持多关键字检索。
        //如果需要按POI分类进行检索，请将分类通过query参数进行设置，如query=美食
        private String query;

        //检索分类偏好，与q组合进行检索，多个分类以","分隔
        //（POI分类），如果需要严格按分类检索，请通过query参数设置
        private String tag;

        //检索行政区划区域（增加区域内数据召回权重，如需严格限制召回数据在区域内，请搭配使用city_limit参数），可输入行政区划名或对应cityCode
        private String region;

        //区域数据召回限制，为true时，仅召回region对应区域内数据。
        private Boolean cityLimit;

        //输出格式为json或者xml
        private String output;

        //检索结果详细程度。取值为1 或空，则返回基本信息；取值为2，返回检索POI详细信息
        private String scope;

        /**
         * 
         * 检索过滤条件。当scope取值为2时，可以设置filter进行排序。
            industry_type：行业类型，注意：设置该字段可提高检索速度和过滤精度，取值有： 
            hotel（宾馆）；
            cater（餐饮）；
            life（生活娱乐） 

            sort_name：排序字段，根据industry_type字段的值而定。 
            1、industry_type为hotel时，sort_name取值有： 
            default（默认）；
            price（价格）；
            total_score（好评）；
            level（星级）；
            health_score（卫生）；
            distance（距离排序，只有圆形区域检索有效） 
            2、industry_type为cater时，sort_name取值有： 
            default（默认）；
            taste_rating（口味）；
            price（价格）；
            overall_rating（好评）；
            service_rating（服务）；
            distance（距离排序，只有圆形区域检索有效） 
            3、industry_type为life时，sort_name取值有： 
            default（默认）；
            price（价格）；
            overall_rating（好评）；
            comment_num（服务）；
            distance（距离排序，只有圆形区域检索有效）
            
            sort_rule：排序规则：0（从高到低），1（从低到高）
            price_section：价格区间
            groupon：是否有团购：1（有），0（无）
            discount：是否有打折：1（有），0（无）

            示例：sort_name:distance|sort_rule:1
        */
        private String filter;

        /**
         * 坐标类型，
         * 1（wgs84ll即GPS经纬度），
         * 2（gcj02ll即国测局经纬度坐标），
         * 3（bd09ll即百度经纬度坐标），
         * 4（bd09mc即百度米制坐标）
            注："ll为小写LL"
        */
        private int coordType;

        //可选参数，添加后POI返回国测局经纬度坐标
        private String retCoordtype;

        public PlaceSearchRequestDTO()
        {
            coordType = (int)CoordTypeEnum.wgs84ll;
        }

        public PlaceSearchRequestDTO(string query, string tag, string region, bool cityLimit, string output, string scope, string filter, int coordType, string retCoordtype)
        {
            this.query = query;
            this.tag = tag;
            this.region = region;
            this.CityLimit = cityLimit;
            this.output = output;
            this.scope = scope;
            this.filter = filter;
            this.CoordType = coordType;
            this.retCoordtype = retCoordtype;
        }

        public string Query { get => query; set => query = value; }
        public string Tag { get => tag; set => tag = value; }
        public string Region { get => region; set => region = value; }
        public string Output { get => output; set => output = value; }
        public string Scope { get => scope; set => scope = value; }
        public string Filter { get => filter; set => filter = value; }
        public int CoordType { get => coordType; set => coordType = value; }
        public bool CityLimit { get => cityLimit; set => cityLimit = value; }
        public string RetCoordtype { get => retCoordtype; set => retCoordtype = value; }

        public override string ToString()
        {
            if(query==null|| region == null)
            {
                throw new Exception("参数错误，query或者region其中一个参数为空！");
            }
            
            return base.ToString();
        }
    }
}
