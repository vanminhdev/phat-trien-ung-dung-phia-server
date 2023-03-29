using Filter_DCSon.DbContexts;
using Filter_DCSon.Dto;
using Filter_DCSon.Entities;

namespace Filter_DCSon.Services
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly ILogger _logger;
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public StudentSubjectService(ILogger<StudentService> logger, MyDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // add new
        public void Add(int subjectId, int studentId, float score)
        {
            _dbContext.StudentSubjects.Add(new Entities.StudentSubject
            {
                SubjectId = subjectId,
                StudentId = studentId,
                Score = score
            });
            _dbContext.SaveChanges();
        }

        // update
        public void Update(int subjectId, int studentId, float score)
        {
            // update
            var result = _dbContext.StudentSubjects.FirstOrDefault(x => x.StudentId == studentId
                                                    && x.SubjectId == subjectId);

            result.Score = score;
            _dbContext.SaveChanges();
        }

        // add Score of Subject with student id and subject id 
        public void AddScoreWithSubject(int studentId, int subjectId, float score)
        {

            var classroom = _dbContext.Subjects.FirstOrDefault(c => c.Id == subjectId);
            if (classroom == null)
            {
                throw new Exception("Không tìm thấy lớp học");
            }
            var isCheck = _dbContext.StudentSubjects
                .Any(sc => sc.StudentId == studentId && sc.SubjectId == subjectId);
            
            //kiểm tra sinh vien va mon hoc ton tai
            if (isCheck)
            {
                Update(subjectId, studentId, score);
            }
            else
            {
                Add(subjectId, studentId, score);
            }
        }

        public List<Student> GetStudentBySubject(int subjectId)
        {
            var studentIds = _dbContext.StudentSubjects
                .Where(sc => sc.SubjectId == subjectId).Select(sc => sc.StudentId).ToList();

            var students = _dbContext.Students.Where(s => studentIds.Contains(s.Id)).ToList();

            //sử dụng join cách 1 dùng method
            var join1 = _dbContext.StudentSubjects.Where(sc => sc.SubjectId == subjectId)
                .Join(_dbContext.Students, sc => sc.StudentId, s => s.Id,
                (studentSubject, student) => new { student });

            var result1 = join1.Select(o => o.student).ToList();

            //sử dụng join cách 2 dùng syntax
            var join2 = from studentSubject in _dbContext.StudentSubjects
                        join student in _dbContext.Students on studentSubject.StudentId equals student.Id
                        where studentSubject.SubjectId == subjectId
                        select new
                        {
                            student
                        };

            var result2 = join2.Select(o => o.student).ToList();
            //result1 và result2 cùng cho ra 1 kết quả.

            return result1;
        }

        public void RemoveStudentBySubject(int studentId, int subjectId)
        {

            var studentSubjects = _dbContext.StudentSubjects.FirstOrDefault(c => c.SubjectId == subjectId && c.StudentId == studentId);
            if (studentSubjects == null)
            {
                throw new Exception("Không tìm thấy lớp học");
            }

            _dbContext.StudentSubjects.Remove(studentSubjects);
            _dbContext.SaveChanges();
        }

        public List<GetScoreOfStudentDto> GetScoreOfStudent(int studentId)
        {
            var subjectIds = _dbContext.StudentSubjects
                .Where(sc => sc.StudentId == studentId).Select(sc => sc.SubjectId).ToList();

            var subjects = _dbContext.Subjects.Where(s => subjectIds.Contains(s.Id)).ToList();

            //sử dụng join cách 1 dùng method
            var join = _dbContext.StudentSubjects.Where(sc => sc.StudentId == studentId)
                .Join(_dbContext.Subjects, sc => sc.SubjectId, s => s.Id,
                (studentSubject, subject) => new { studentSubject, subject });

            var test = from studentSubject in _dbContext.StudentSubjects
                       join subject in _dbContext.Subjects 
                            on new { studentSubject.SubjectId, studentSubject.StudentId } equals new { SubjectId = subject.Id, StudentId = studentId }
                       where studentSubject.StudentId == studentId
                       select new GetScoreOfStudentDto
                       {
                           Score = studentSubject.Score,
                           SubjectName = subject.Name
                       };

            List<GetScoreOfStudentDto> result = join.Select(o => new GetScoreOfStudentDto 
            {
                Score = o.studentSubject.Score,
                SubjectName = o.subject.Name 
            }).ToList();

            return result;
        }
    }
}
