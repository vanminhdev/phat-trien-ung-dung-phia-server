namespace DemoWebAPI.Dto
{
    public class CreateUserDto
    {
        private string _name;
        public string Name 
        { 
            get => _name; 
            set => _name = value?.Trim(); 
        }

        private string _userName;
        public string UserName 
        { 
            get => _userName; 
            set => _userName = value?.Trim(); 
        }

        private string _password;
        public string Password 
        { 
            get => _password; 
            set => _password = value?.Trim(); 
        }
    }
}
