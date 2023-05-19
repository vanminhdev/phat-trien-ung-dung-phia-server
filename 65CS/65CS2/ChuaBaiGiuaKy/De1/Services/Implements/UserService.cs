using De1.DbContexts;
using De1.Dtos.Common;
using De1.Dtos.User;
using De1.Entities;
using De1.Services.Interfaces;

namespace De1.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(CreateUserDto input)
        {
            _dbContext.Users.Add(new User
            {
                Id = ++ApplicationDbContext.UserId,
                Username = input.Username,
                Password = input.Password,
                Email = input.Email,
                CreatedDate = DateTime.Now,
            });
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("Không tìm thấy user");
            }
            _dbContext.Users.Remove(user);
        }

        public PageResultDto<UserDto> GetAll(UserFilterDto input)
        {
            var result = new PageResultDto<UserDto>();
            var query = _dbContext.Users
                .Where(u => u.Username.Contains(input.Keyword) 
                    && (input.StartDate == null || u.CreatedDate >= input.StartDate)
                    && (input.EndDate == null || u.CreatedDate <= input.EndDate))
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    UserName = u.Username,
                    Email = u.Email,
                    CreatedDate = u.CreatedDate
                });

            //cách 2
            var query2 = from user in _dbContext.Users
                         where user.Username.Contains(input.Keyword) 
                            && (input.StartDate == null || user.CreatedDate >= input.StartDate)
                            && (input.EndDate == null || user.CreatedDate <= input.EndDate)
                         select new UserDto
                         {
                             Id = user.Id,
                             UserName = user.Username,
                             Email = user.Email,
                             CreatedDate = user.CreatedDate
                         };

            result.TotalItem = query.Count();
            query = query.Skip(input.Skip())
                .Take(input.PageSize);

            result.Items = query.ToList();

            return result;
        }

        public void UpdateUser(UpdateUserDto input)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == input.Id);
            if (user == null)
            {
                throw new Exception("Không tìm thấy user");
            }
            user.Username = input.Username;
            user.Password = input.Password;
            user.Email = input.Email;
        }


    }
}
