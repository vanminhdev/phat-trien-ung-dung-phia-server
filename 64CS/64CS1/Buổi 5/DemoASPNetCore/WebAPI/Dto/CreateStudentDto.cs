using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sinh viên không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên sinh viên dài tối thiểu 10 ký tự, tối đa 50 ký tự", MinimumLength = 10)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã sinh viên không được bỏ trống")]
        [StringLength(10, ErrorMessage = "Mã sinh viên dài tối thiểu 3 ký tự, tối đa 10 ký tự", MinimumLength = 3)]
        public string StudentCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        //public IFormFile Avatar { get; set; } //lấy file.
    }
}
