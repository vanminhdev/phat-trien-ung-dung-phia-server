using WebApplication3.Dtos.Users;

namespace WebApplication3.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserDto input);
        string Login(LoginDto input);
    }
}
