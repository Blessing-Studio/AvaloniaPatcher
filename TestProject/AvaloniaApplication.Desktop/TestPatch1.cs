using Avalonia.Controls;
using BlessingStudio.AvaloniaPatcher.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication.Desktop
{
    public class TestPatch1 : EditPatch
    {
        public override ContentLocation GetContentLocation()
        {
            return new("Content");
        }

        public override void OnEdit(Control control)
        {
            TextBlock textBlock = (TextBlock)control;
            textBlock.Text = "patched";
        }
    }
}
