using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos.Students
{
    public class CreateStudentDto
    {
        private string _name;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sinh viên không được bỏ trống")]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }
    }
}
