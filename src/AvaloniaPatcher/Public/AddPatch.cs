using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Public
{
    public abstract class AddPatch : Patch
    {
        public sealed override PatchType PatchType => PatchType.Add;
        public abstract Control GetContext();
        public abstract ContentLocation GetContentLocation();
    }
}
