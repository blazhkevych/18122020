﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18122020
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

}