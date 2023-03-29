using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CreateStudentDto
    {
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên dài tối đa 50 ký tự, tối thiểu 10 ký tự", MinimumLength = 10)]
        [MinLength(50, ErrorMessage = "Tên dài tối thiểu 50 ký tự")]
        public string Name { get; set; }

        [MinLength(1, ErrorMessage = "Danh sách điểm không được bỏ trống")]
        public List<double> Score { get; set; }

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Giá trị tối thiểu lớn hơn 0")]
        public double Value { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Email định dạng không hợp lệ")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.(com|net|org|gov)$", ErrorMessage = "Email định dạng không hợp lệ")]
        public string Email { get; set; }

        [Required]
        public string StudentCode { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public IFormFile Avatar { get; set; }
    }
}
