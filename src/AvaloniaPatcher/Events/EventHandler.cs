﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Events
{
    public delegate void EventHandler<T>(T e) where T : IEvent;
}
