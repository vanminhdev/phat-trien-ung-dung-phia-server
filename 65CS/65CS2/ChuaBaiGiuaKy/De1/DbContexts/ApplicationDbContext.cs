using De1.Entities;

namespace De1.DbContexts
{
    public class ApplicationDbContext
    {
        public List<User> Users { get; set; }
        public static int UserId = 0;
    }
}
