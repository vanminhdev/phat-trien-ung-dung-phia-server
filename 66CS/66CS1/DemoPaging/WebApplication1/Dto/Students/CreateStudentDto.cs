using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto.Students
{
    public class CreateStudentDto
    {
        private string _name;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        //[StringLength(50, ErrorMessage = "Tên dài tối đa 50 ký tự")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        private string _studentCode;
        [Required(ErrorMessage = "Tên không được bỏ trống")]
        public string StudentCode
        {
            get => _studentCode;
            set => _studentCode = value?.Trim();
        }
        public DateTime DateOfBirth { get; set; }

        //[Range(double.Epsilon, 100)] //lấy bằng đoạn: từ số nhỏ nhất kiểu double lớn hơn 0 tới 100
        //public double Score { get; set; }
    }
}
