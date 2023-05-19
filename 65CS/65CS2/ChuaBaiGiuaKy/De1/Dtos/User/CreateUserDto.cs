using System.ComponentModel.DataAnnotations;

namespace De1.Dtos.User
{
    public class CreateUserDto
    {
        private string _username;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tài khoản không được bỏ trống")]
        [MaxLength(50, ErrorMessage = "Tài khoản dài tối đa 50 ký tự")]
        [MinLength(3, ErrorMessage = "Tài khoản dài tối thiểu 3 ký tự")]
        public string Username 
        { 
            get => _username;
            set => _username = value?.Trim(); 
        }

        private string _password;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password
        {
            get => _password;
            set => _password = value?.Trim();
        }

        private string _email;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email
        {
            get => _email;
            set => _email = value?.Trim();
        }
    }
}
