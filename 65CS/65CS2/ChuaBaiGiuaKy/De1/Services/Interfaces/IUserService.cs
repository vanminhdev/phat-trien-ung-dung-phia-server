using De1.Dtos.Common;
using De1.Dtos.User;

namespace De1.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto input);
        void UpdateUser(UpdateUserDto input);
        PageResultDto<UserDto> GetAll(UserFilterDto input);
        void DeleteUser(int userId);
    }
}
