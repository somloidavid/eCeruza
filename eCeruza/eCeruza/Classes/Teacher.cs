﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCeruza.Classes
{
    public class Teacher
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public Dictionary<string, string[]>? ClassSubject { get; set; }
    }
}
