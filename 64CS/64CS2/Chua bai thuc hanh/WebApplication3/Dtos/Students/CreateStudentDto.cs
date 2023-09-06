using System.ComponentModel.DataAnnotations;

namespace WebApplication.Dtos.Students
{
    public class CreateStudentDto
    {
        private string _name;
        [MaxLength(50)]
        public string Name 
        { 
            get => _name; 
            set => _name = value?.Trim(); 
        }

        public DateTime DateOfBirth { get; set; }

        private string _studentCode;
        [MaxLength(50)]
        public string StudentCode 
        { 
            get => _studentCode; 
            set => _studentCode = value?.Trim(); 
        }
    }
}
