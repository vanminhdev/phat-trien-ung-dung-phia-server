using System.ComponentModel.DataAnnotations;

namespace De5.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        private string _code;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã nhân viên không được bỏ trống")]
        [MaxLength(20, ErrorMessage = "Mã nhân viên tối đa 20 ký tự")]
        public string Code
        {
            get => _code; 
            set => _code = value?.Trim();
        }

        private string _name;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên nhân viên không được bỏ trống")]
        [MaxLength(128, ErrorMessage = "Tên nhân viên không được dài quá 128 ký tự")]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }

        public int Age { get; set; }

        private string _address;
        [MaxLength(512, ErrorMessage = "Địa chỉ không được dài quá 512 ký tự")]
        public string Address
        {
            get => _address;
            set => _address = value?.Trim();
        }
    }
}
