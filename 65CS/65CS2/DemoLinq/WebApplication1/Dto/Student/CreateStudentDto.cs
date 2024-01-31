using System.ComponentModel.DataAnnotations;
using WebApplication1.Validations;

namespace WebApplication1.Dto.Student
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Tuổi phải lớn hơn 0")]
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        //[StringRange(AllowableValues = new string[] { "NT", "2NT" })]
        //public string StudentType { get; set; }
    }
}
