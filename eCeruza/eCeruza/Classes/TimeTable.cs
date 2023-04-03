using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza.Classes
{
    internal class TimeTable
    {
        public string? Class { get; set; }
        public Dictionary<string, Dictionary<string, string[]>> Day{ get; set; }
    }
}
