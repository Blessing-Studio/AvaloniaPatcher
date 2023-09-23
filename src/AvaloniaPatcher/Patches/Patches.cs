using Avalonia.Controls;
using BlessingStudio.AvaloniaPatcher.Public;
using BlessingStudio.AvaloniaPatcher.Utils;
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
                if(AvaloniaPatcher.LoadedPatches.ContainsKey(type))
                {
                    List<Patch> patchList = AvaloniaPatcher.LoadedPatches[type];
                    foreach (Patch patch in patchList)
                    {
                        if(patch is AddPatch addPatch)
                        {
                            object tmp = ContentLocationUtils.GetValue(control, addPatch.GetContentLocation().Location);
                            MethodInfo methodInfo = tmp.GetType().GetMethod("Add")!;
                            methodInfo.Invoke(tmp, new object[] { addPatch.GetContext() });
                        }
                    }
                }
                AvaloniaPatcher.CallControlLoadedEvent(new Events.ControlLoadedEvent(control));
            }
        }
        public static MethodInfo GetPostfixMethodInfo()
        {
            MethodInfo method = typeof(Patches).GetMethod("Postfix")!;
            return method;
        }
    }
}
