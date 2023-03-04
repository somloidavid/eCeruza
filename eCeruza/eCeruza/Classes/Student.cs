using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza.Classes
{
    public class Student
    {
        public string? Name { get; set; }
        public string? Password {get; set; }
        public string? Class { get; set; }
        public List<string>? Subjects { get; set; }
        static List<Grade>? Grades { get; set; }
    }
}