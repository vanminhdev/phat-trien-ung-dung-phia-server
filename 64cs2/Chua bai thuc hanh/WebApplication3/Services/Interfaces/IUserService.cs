using WebApplication3.Dto.Users;

namespace WebApplication3.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateUserDto input);
        string Login(LoginDto input);
    }
}
