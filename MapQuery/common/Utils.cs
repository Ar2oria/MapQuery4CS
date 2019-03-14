using MapQuery.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapQuery.common
{
    public class Utils
    {
        public static OptionEnum GetFormRadio(GroupBox group)
        {
            var controls = group.Controls;
            foreach (var item in controls)
            {
                if (item is RadioButton)
                {
                    if (((RadioButton)item).Checked)
                    {
                        int o = int.Parse(((RadioButton)item).Tag.ToString());
                        return  (OptionEnum)o;
                    }
                }
            }
            return OptionEnum.none;
        }
    }
}
