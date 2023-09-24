using Avalonia.Controls;
using BlessingStudio.AvaloniaPatcher.Events;
using BlessingStudio.AvaloniaPatcher.Public;
using BlessingStudio.AvaloniaPatcher.Utils;
using HarmonyLib;
using System.Reflection;

namespace BlessingStudio.AvaloniaPatcher
{
    public static class AvaloniaPatcher
    {
        public static event Events.EventHandler<ControlLoadedEvent>? OnControlLoadedEvent;
        private static List<Assembly> InitedAssemblies = new();
        private static List<Type> InitedTypes = new();
        public static Dictionary<Type, Control> InstancesOfControls = new();
        public static Dictionary<Type, List<Patch>> LoadedPatches = new();
        public static Harmony Harmony { get; private set; } = new("BlesaingStudio.AvaloniaPatcher");
        public static bool IsInitedAssembly(Assembly assembly)
        {
            return InitedAssemblies.Contains(assembly);
        }
        public static bool IsInitedType(Type type)
        {
            return InitedTypes.Contains(type);
        }
        public static void Init(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Control)) && !IsInitedType(type))
                {
                    foreach (ConstructorInfo constructor in type.GetConstructors())
                    {
                        Harmony.Patch(constructor, postfix: new(Patches.Patches.GetPostfixMethodInfo()));
                    }
                    InitedTypes.Add(type);
                }
            }
            InitedAssemblies.Add(assembly);
        }
        public static void Patch(Type type, Patch patch)
        {
            if (!LoadedPatches.ContainsKey(type))
            {
                LoadedPatches[type] = new();
            }
            LoadedPatches[type].Add(patch); if (InstancesOfControls.ContainsKey(type))
            {
                if (patch is AddPatch addPatch)
                {
                    object tmp = ContentLocationUtils.GetValue(InstancesOfControls[type], addPatch.GetContentLocation().Location);
                    MethodInfo methodInfo = tmp.GetType().GetMethod("Add")!;
                    methodInfo.Invoke(tmp, new object[] { addPatch.GetContext() });
                }
                else if (patch is EditPatch editPatch)
                {
                    Control tmp = ContentLocationUtils.GetValue(InstancesOfControls[type], editPatch.GetContentLocation().Location);
                    editPatch.OnEdit(tmp);
                }
            }
        }



        public static void CallControlLoadedEvent(ControlLoadedEvent @event)
        {
            if (OnControlLoadedEvent != null)
            {
                OnControlLoadedEvent(@event);
            }
        }
    }
}
