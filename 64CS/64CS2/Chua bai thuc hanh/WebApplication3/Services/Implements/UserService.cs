using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication.Constants;
using WebApplication.DbContexts;
using WebApplication.Dtos.Users;
using WebApplication.Entities;
using WebApplication.Exceptions;
using WebApplication.Services.Interfaces;
using WebApplication.Utils;

namespace WebApplication.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService(
            ILogger<StudentService> logger,
            ApplicationDbContext dbContext, 
            IConfiguration configuration)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public void Create(CreateUserDto input)
        {
            if (_dbContext.Users.Any(u => u.Username == input.Username))
            {
                throw new UserFriendlyException($"Tên tài khoản \"{input.Username}\" đã tồn tại");
            }
            _dbContext.Users.Add(new User
            {
                Username = input.Username,
                Password = CommonUtils.CreateMD5(input.Password),
                UserType = input.UserType
            });
            _dbContext.SaveChanges();
        }

        public string Login(LoginDto input)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == input.Username);
            if (user == null)
            {
                throw new UserFriendlyException($"Tài khoản \"{input.Username}\" không tồn tại");
            }

            if (CommonUtils.CreateMD5(input.Password) == user.Password)
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.Username),
                    new Claim(CustomClaimTypes.UserType, user.UserType.ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(_configuration.GetValue<int>("JWT:Expires")),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                throw new UserFriendlyException($"Mật khẩu không chính xác");
            }
        }
    }
}
