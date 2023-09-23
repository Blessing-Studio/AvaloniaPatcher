using Avalonia.Controls;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPatcher
{
    public static class AvaloniaPatcher
    {
        private static List<Assembly> InitedAssemblies = new();
        private static List<Type> InitedTypes = new();
        public static Dictionary<Type, Control> InstancesOfControls = new();
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
            foreach(Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Control)) && !IsInitedType(type))
                {
                    foreach(ConstructorInfo constructor in type.GetConstructors())
                    {
                        Harmony.Patch(constructor, postfix: new(Patches.Patches.GetPostfixMethodInfo()));
                    }
                    InitedTypes.Add(type);
                }
            }InitedAssemblies.Add(assembly);
        }

    }
}
