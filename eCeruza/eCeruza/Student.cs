using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza
{
    internal class Student : Account
    {
        public string Class { get; set; }
        public string[] Subjects { get; set; }
        public List<Grade> Grades { get; set; }
        public Student(string row) : base(row)
        {
        }
    }
}