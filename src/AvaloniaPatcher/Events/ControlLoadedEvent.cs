using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPatcher.Events
{
    public class ControlLoadedEvent : IEvent
    {
        public Control Control { get; private set; }
        public ControlLoadedEvent(Control control)
        {
            Control = control;
        }
        public string GetName()
        {
            return "ControlLoadedEvent";
        }
    }
}
