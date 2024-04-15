using WebAPI.DbContexts;
using WebAPI.Dtos.Classrooms;
using WebAPI.Dtos.Students;
using WebAPI.Entities;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Implements
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationDbContext _dbContext;

        public ClassroomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(AddStudentToClassDto input)
        {
            foreach (var studentId in input.StudentIds)
            {
                _dbContext.StudentClasses.Add(
                    new StudentClassroom
                    {
                        Id = ++_dbContext.StudentClassroomId,
                        ClassroomId = input.ClassroomId,
                        StudentId = studentId,
                    }
                );
            }
        }

        public List<StudentDto> GetAllStudent(int clasroomId)
        {
            //cách 1: linq syntax
            var result =
                from studentClass in _dbContext.StudentClasses
                join student in _dbContext.Students on studentClass.StudentId equals student.Id
                join classroom in _dbContext.Classrooms
                    on studentClass.ClassroomId equals classroom.Id
                where studentClass.ClassroomId == clasroomId
                select new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    DateOfBirth = student.DateOfBirth,
                    //ClassroomName = classroom.Name
                };

            //cách 2: linq method
            var result2 = _dbContext
                .StudentClasses.Join(
                    _dbContext.Students,
                    sc => sc.StudentId,
                    s => s.Id,
                    (studentClassroom, student) => new { studentClassroom, student }
                )
                .Join(
                    _dbContext.Classrooms,
                    sc => sc.studentClassroom.ClassroomId,
                    c => c.Id,
                    (sc, c) => new StudentDto {
                        Id = sc.studentClassroom.Id,
                        Name = sc.student.Name,
                        DateOfBirth = sc.student.DateOfBirth,
                    }
                );

            //cách 3: sử dụng các navigation property và viết các hàm include (sẽ giới thiệu trong ef core)

            return result.ToList();
        }
    }
}
