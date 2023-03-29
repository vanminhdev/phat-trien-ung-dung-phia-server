using System.ComponentModel.DataAnnotations;

namespace Filter_DCSon.Dto
{
    public class CreateSubjectDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên lớp học không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên lớp học tối đa 50 ký tự")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã lớp học không được bỏ trống")]
        [MinLength(5, ErrorMessage = "Mã lớp học tối thiểu 5 ký tự")]
        public string SubjectCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Số tín chỉ không được bỏ trống")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Số tín chỉ phải lớn hơn 0")]

        public int NumberCredits { get; set; }
    }
}
