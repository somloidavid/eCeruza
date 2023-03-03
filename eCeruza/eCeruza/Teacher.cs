using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza
{
    internal class Teacher : Account
    {
        public string[] Classes { get; set; }
        public Dictionary<string,string> ClassSubject { get; set; }
        
        public Teacher(string row) : base(row)
        {
        }
    }
}
