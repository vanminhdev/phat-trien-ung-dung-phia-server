using WebAPI.Entities;

namespace WebAPI.DbContexts
{
    public class ApplicationDbContext
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public int Id { get; set; } = 0;

        public ApplicationDbContext()
        {
        }
    }
}
