using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Public
{
    public abstract class EditPatch : Patch
    {
        public override PatchType PatchType => PatchType.Edit;

        public abstract void OnEdit(Control control);
        public abstract ContentLocation GetContentLocation();
    }
}
