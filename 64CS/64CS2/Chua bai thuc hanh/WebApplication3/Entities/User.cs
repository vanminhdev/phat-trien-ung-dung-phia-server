using System.Security.Claims;

namespace WebApplication.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
