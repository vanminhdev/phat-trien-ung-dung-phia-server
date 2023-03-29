using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObject
{
    public class Wine
    {
        public decimal Price { get; set; }
        public int Year { get; set; }

        private string _name;
        public string Name 
        { 
            get => _name; 
            set => _name = value?.Trim();
        }

        //public Wine(decimal price)
        //{
        //    Price = price;
        //}

        //public Wine(decimal price, int year) : this(price) 
        //{ 
        //    Year = year; 
        //}
    }
}
