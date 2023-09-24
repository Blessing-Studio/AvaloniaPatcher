using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Utils
{
    public static class ContentLocationUtils
    {
        public static Control GetValue(Control control, string location)
        {
            string[] properties = location.Split('.');
            int i = 0;
            object tmp = control;
            PropertyInfo contentInfo = tmp.GetType().GetProperty("Content")!;
            tmp = contentInfo.GetValue(tmp, null)!;
            while (true)
            {
                if(i >= properties.Length) break;
                if(location == string.Empty) break;
                if (properties[i].StartsWith("[") && properties[i].EndsWith("]"))
                {
                    int index = int.Parse(properties[i].Replace("[", string.Empty).Replace("]", string.Empty));
                    PropertyInfo item = tmp.GetType().GetProperty("Item")!;
                    tmp = item.GetValue(tmp, new object[] { index })!;
                    i++;
                    continue;
                }
                PropertyInfo propertyInfo = tmp.GetType().GetProperty(properties[i])!;
                tmp = propertyInfo.GetValue(tmp, null)!;
                i++;
            }
            return (Control)tmp;
        }
    }
}
