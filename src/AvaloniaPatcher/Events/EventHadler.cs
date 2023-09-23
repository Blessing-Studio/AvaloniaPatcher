using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaPatcher.Events
{
    public delegate void EventHadler<T>(T e) where T : IEvent;
}
