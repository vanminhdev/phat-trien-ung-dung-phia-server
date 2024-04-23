using Microsoft.AspNetCore.Components.Forms;
using WebApplication1.DbContexts;
using WebApplication1.Dto.Classrooms;
using WebApplication1.Dto.Students;
using WebApplication1.Entity;
using WebApplication1.Exceptions;
using WebApplication1.Services.Abstract;

namespace WebApplication1.Services.Implements
{
    public class ClassroomService
        : ClassroomBaseService,
            IClassroomService,
            IStudentClassroomService
    {
        public ClassroomService(ApplicationDbContext dbContext)
            : base(dbContext) { }

        public void AddStudents(AddStudentToClassDto input)
        {
            //kiểm tra lớp đã đủ sinh viên chưa
            //gợi ý hàm này nên đẩy lên class base vì có thể dùng lại !!!
            var classroom = _dbContext.Classrooms.FirstOrDefault(c => c.Id == input.ClassroomId);
            if (classroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp có id = {input.ClassroomId}");
            }

            //số sinh viên hiện tại
            int currentNumStudent = _dbContext
                .StudentClasses.Where(sc => sc.ClassroomId == input.ClassroomId)
                .Count();
            if (currentNumStudent + input.StudentIds.Count > classroom.MaxStudent)
            {
                throw new UserFriendlyException("Lớp không còn đủ chỗ");
            }

            foreach (var studentId in input.StudentIds)
            {
                //kiểm tra sinh viên có id là studentId đã được thêm chưa
                var studentFind = _dbContext.StudentClasses.FirstOrDefault(s =>
                    s.StudentId == studentId && s.ClassroomId == input.ClassroomId
                );

                if (studentFind != null)
                {
                    // báo lỗi hoặc bỏ qua
                    continue;
                }

                _dbContext.StudentClasses.Add(
                    new StudentClassroom
                    {
                        //Id = ++_dbContext.StudentClassroomId,
                        StudentId = studentId,
                        ClassroomId = input.ClassroomId,
                    }
                );
            }
        }

        public List<StudentDto> GetAllStudent(int classroomId)
        {
            //cách 1: linq query syntax
            var query =
                from studentClassroom in _dbContext.StudentClasses
                join student in _dbContext.Students on studentClassroom.StudentId equals student.Id
                join classroom in _dbContext.Classrooms
                    on studentClassroom.ClassroomId equals classroom.Id
                where studentClassroom.ClassroomId == classroomId
                select new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    StudentCode = student.StudentCode,
                    DateOfBirth = student.DateOfBirth,
                };

            //cách 2: linq method syntax
            var query2 = _dbContext
                .StudentClasses.Join(
                    _dbContext.Students,
                    sc => sc.StudentId,
                    s => s.Id,
                    (studentClassroom, student) => new { studentClassroom, student }
                )
                .Where(sc => sc.studentClassroom.ClassroomId == classroomId)
                .Join(
                    _dbContext.Classrooms,
                    sc => sc.studentClassroom.ClassroomId,
                    c => c.Id,
                    (sc, c) => new StudentDto 
                    {
                        Id = sc.student.Id,
                        Name = sc.student.Name,
                        StudentCode = sc.student.StudentCode,
                        DateOfBirth = sc.student.DateOfBirth,
                    }
                );

            //cách 3: ef core cấu hình các navigation property và dùng các hàm include

            //return query.ToList();
            return query2.ToList();
        }
    }
}
