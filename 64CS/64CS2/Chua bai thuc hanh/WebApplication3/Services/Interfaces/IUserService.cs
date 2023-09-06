using WebApplication.Dtos.Users;

namespace WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserDto input);
        string Login(LoginDto input);
    }
}
