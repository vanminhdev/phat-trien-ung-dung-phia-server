using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Dtos.Students
{
    public class UpdateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
