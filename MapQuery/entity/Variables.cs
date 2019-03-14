using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapQuery
{
    public class Variables
    {
        public static void GetPoints (WebBrowser web){
            CenterX = GetValue(web, "centerX");
            CenterY = GetValue(web, "centerY");
            LastPointX = GetValue(web, "lastPointX");
            LastPointY = GetValue(web, "lastPointY");
            Radius = GetValue(web, "radius");
            LastRectPointX1 = GetValue(web, "lastRectPointX1");
            LastRectPointX2 = GetValue(web, "lastRectPointX2");
            LastRectPointY1 = GetValue(web, "lastRectPointY1");
            LastRectPointY2 = GetValue(web, "lastRectPointY2");
        }

        private static double GetValue(WebBrowser web, String str)
        {
            var elem = web.Document.GetElementById(str);
            var v = elem.GetAttribute("value");
            double.TryParse(v, out double d);
            return d;
        }
        public static double CenterX
        {
            get;
            set;
        }
        public static double CenterY
        {
            get;
            set;
        }
        public static double LastPointX
        {
            get;
            set;
        }
        public static double LastPointY
        {
            get;
            set;
        }
        public static double Radius
        {
            get;
            set;
        }
        public static double LastRectPointX1
        {
            get;
            set;
        }
        public static double LastRectPointY1
        {
            get;
            set;
        }
        public static double LastRectPointX2
        {
            get;
            set;
        }
        public static double LastRectPointY2
        {
            get;
            set;
        }
    }
}
