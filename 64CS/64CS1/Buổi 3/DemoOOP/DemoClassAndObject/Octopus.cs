using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassAndObject
{
    public class Octopus
    {
        private string _name;
        public string Name 
        { 
            get => _name;
            set => _name = value?.Trim();
        }
        public int Age { get; set; }
        public DateTime? Date { get; set; }
        public char CharA { get; set; }
        public const string Message = "Hello World";

        //public Octopus()
        //{
        //}

        //public Octopus(string name, int age, DateTime? date, char charA)
        //{
        //    Name=name;
        //    Age=age;
        //    Date=date;
        //    this.CharA=charA;
        //}

        public int Foo(int x) 
        {
            return x + 2;
        }

        public void Foo(double x) 
        {
        }

        public void Foo(int x, float y)
        {
        }

        public void Foo(float x, int y)
        {
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }
}
