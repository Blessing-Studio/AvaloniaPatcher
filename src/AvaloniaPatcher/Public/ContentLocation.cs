using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlessingStudio.AvaloniaPatcher.Public
{
    public class ContentLocation
    {
        public string Location;
        public int? Index;
        public ContentLocation(string location, int? index = null)
        {
            Location = location;
            Index = index;
        }
    }
}
