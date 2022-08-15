using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    /// <summary>
    /// Giải thích ở đây.
    /// </summary>
    public class Octopus
    {
        //public string Name { get; set; }

        private string _name;
        public string Name 
        {
            get => _name;
            set => _name = value?.Trim(); 
        }

        public int Age { get; set; }
        public static char CharA { get; set; }

        public const string ClassRoom = "64cs3";
    }
}
