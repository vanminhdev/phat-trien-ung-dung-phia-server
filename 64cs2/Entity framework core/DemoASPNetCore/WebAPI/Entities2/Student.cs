using System;
using System.Collections.Generic;

namespace WebAPI.Entities2
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }
    }
}
