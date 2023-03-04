﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza.Classes
{
    internal class Student
    {
        public string? Name { get; set; }
        public string? Password {get; set; }
        public string? Class { get; set; }
        public List<string>? Subjects { get; set; }
        public List<Grade>? Grades { get; set; }
    }
}