using System.ComponentModel.DataAnnotations;

namespace Filter_DCSon.Dto
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sinh viên không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên sinh viên tối đa 50 ký tự")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã sinh viên không được bỏ trống")]
        public string StudentCode { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        //public IFormFile Avatar { get; set; } //lấy file.
    }
}
