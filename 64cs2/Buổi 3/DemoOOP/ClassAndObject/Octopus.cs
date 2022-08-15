using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    public class Octopus
    {
        private string Name; //default access modifier
        public int Age;
        public readonly char CharA;

        public static string Gender = "Men";

        public Octopus(string name, int age, char charA)
        {
            Name=name;
            Age=age;
            CharA=charA;
        }

        public int Foo(int x)
        {
            return x * 2;
        }

        //public int Foo(int x) => x * 2;

        public int Sum(int x) 
        {
            return x + 1;
        }

        public double Sum(double x) 
        {
            return x + 2;
        }

        public float Sum(int x, float y) 
        {
            return x + y;
        }

        public float Sum(float x, int y) 
        {
            return x + y;
        }
    }
}
