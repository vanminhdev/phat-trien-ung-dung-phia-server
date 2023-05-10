using WebApplication1.DbContexts;
using WebApplication1.Dto.Student;
using WebApplication1.Entities;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implements
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationDbContext _context;

        public ClassroomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StudentDto> GetAllStudent(int classroomId)
        {
            var query = from studentClassroom in _context.StudentClassroom
                        join student in _context.Students on studentClassroom.StudentId equals student.Id
                        where studentClassroom.ClassroomId == classroomId
                        orderby student.Age descending, student.Id descending
                        select new StudentDto
                        {
                            Id = student.Id,
                            Name = student.Name,
                            Age = student.Age,
                        };
            return query.ToList();
        }

        public List<StudentDto> GetAllStudent2(int classroomId)
        {
            var list = _context.StudentClassroom.Join(_context.Students, sc => sc.StudentId, s => s.Id,
                (studentClassroom, student) => new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age,
                })
                .OrderByDescending(s => s.Age)
                .ThenByDescending(s => s.Id)
                .ToList();
            return list;
        }

        public List<StudentDto> GetAllStudentMaxAge(int classroomId)
        {
            var studentClassroomQuery = from studentClassroom in _context.StudentClassroom
                                        join student in _context.Students on studentClassroom.StudentId equals student.Id
                                        where studentClassroom.ClassroomId == classroomId
                                        select student;

            int maxAge = studentClassroomQuery.Max(s => s.Age);

            var studentQuery = from studentClassroom in _context.StudentClassroom
                        join student in _context.Students on studentClassroom.StudentId equals student.Id
                        where studentClassroom.ClassroomId == classroomId && student.Age == maxAge
                        select new StudentDto
                        {
                            Id = student.Id,
                            Name = student.Name,
                            Age = student.Age,
                        };
            return studentQuery.ToList();

            //return studentClassroomQuery.Where(s => s.Age == maxAge).Select(s => new StudentDto
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    Age = s.Age,
            //}).ToList();
        }
    }
}
