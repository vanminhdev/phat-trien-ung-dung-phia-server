using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo
{
    internal class Student
    {
        public int Id { get; set; }

        //private int Id;
        //public int GetId()
        //{
        //    return Id;
        //}

        //public void SetId(int id)
        //{
        //    Id = id;
        //}

        public string Name { get; set; }

        public override string ToString()
        {
            return Id + " " + Name;
        }
    }
}
