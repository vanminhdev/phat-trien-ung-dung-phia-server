namespace WebApplication3.Dto.Users
{
    public class CreateUserDto
    {
        private string _username;
        public string Username 
        { 
            get => _username; 
            set => _username = value?.Trim(); 
        }

        private string _password;
        public string Password 
        { 
            get => _password; 
            set => _password = value?.Trim(); 
        }

        public int UserType { get; set; }
    }
}
