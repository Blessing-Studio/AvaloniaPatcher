using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Patches
{
    public static class Patches
    {
        public static void Postfix(object __instance)
        {
            Type type = __instance.GetType();
            if (AvaloniaPatcher.IsInitedType(type))
            {
                Control control = (Control)__instance;
                AvaloniaPatcher.InstancesOfControls[type] = control;
            }
        }
        public static MethodInfo GetPostfixMethodInfo()
        {
            MethodInfo method = typeof(Patches).GetMethod("Postfix")!;
            return method;
        }
    }
}
