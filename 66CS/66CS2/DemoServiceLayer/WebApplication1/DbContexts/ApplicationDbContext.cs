using WebApplication1.Entity;

namespace WebApplication1.DbContexts
{
    /// <summary>
    /// Dùng để kết nối db
    /// </summary>
    public class ApplicationDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int Id { get; set; } = 0;

        public ApplicationDbContext()
        {
        }
    }
}
