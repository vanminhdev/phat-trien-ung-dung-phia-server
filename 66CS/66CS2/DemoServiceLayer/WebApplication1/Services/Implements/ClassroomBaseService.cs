using WebApplication1.DbContexts;
using WebApplication1.Entity;
using WebApplication1.Exceptions;

namespace WebApplication1.Services.Implements
{
    public class ClassroomBaseService
    {
        protected readonly ApplicationDbContext _dbContext;

        public ClassroomBaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //các công việc chung cho quản lý sinh viên và lớp môn học

        //hàm tìm kiếm sinh viên theo id
        protected Student FindStudentById(int studentId)
        {
            var studentFind = _dbContext.Students.Find(s => s.Id == studentId && !s.IsDeleted);
            if (studentFind == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id {studentId}");
            }

            return studentFind;
        }
    }
}
