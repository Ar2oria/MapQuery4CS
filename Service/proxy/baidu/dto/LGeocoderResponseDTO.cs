using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.proxy.baidu.dto
{
    public class LGeocoderResponseDTO
    {

        public LGeocoderResponseDTO() { }
        /**
         * 地址理解程度。分值范围0-100，分值越大，服务对地址理解程度越高（建议以该字段作为解析结果判断标准）；
            当comprehension值为以下值时，对应的准确率如下：
            comprehension=100，解析误差100m内概率为91%，误差500m内概率为96%；
            comprehension≥90，解析误差100m内概率为89%，误差500m内概率为96%；
            comprehension≥80，解析误差100m内概率为88%，误差500m内概率为95%；
            comprehension≥70，解析误差100m内概率为84%，误差500m内概率为93%；
            comprehension≥60，解析误差100m内概率为81%，误差500m内概率为91%；
            comprehension≥50，解析误差100m内概率为79%，误差500m内概率为90%；
            //解析误差：地理编码服务解析地址得到的坐标位置，与地址对应的真实位置间的距离。
    */
        private int comprehension;

        /**
         * 可信度，描述打点准确度，大于80表示误差小于100m。该字段仅作参考，逐步废弃。
         */
        private int confidence;

        /**
         * 能精确理解的地址类型，包含：UNKNOWN、国家、省、城市、区县、乡镇、村庄、道路、地产小区、商务大厦、政府机构、交叉路口、商圈、生活服务、休闲娱乐、餐饮、宾馆、购物、金融、教育、医疗 、工业园区 、旅游景点 、汽车服务、火车站、长途汽车站、桥 、停车场/停车区、港口/码头、收费区/收费站、飞机场 、机场 、收费处/收费站 、加油站、绿地、门址
         */
        private string level;

        /**
         * 经纬度坐标
         */
        private Location location;

        /**
         * 位置的附加信息，是否精确查找。1为精确查找，即准确打点；0为不精确，即模糊打点。
         */
        private int precise;

        public int Comprehension { get => comprehension; set => comprehension = value; }
        public int Confidence { get => confidence; set => confidence = value; }
        public string Level { get => level; set => level = value; }
        public Location Location { get => location; set => location = value; }
        public int Precise { get => precise; set => precise = value; }
    }
}
