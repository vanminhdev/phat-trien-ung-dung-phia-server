using WebApplication3.DbContexts;
using WebApplication3.Dto.Shared;
using WebApplication3.Dto.Subjects;
using WebApplication3.Entities;
using WebApplication3.Exceptions;
using WebApplication3.Services.Interfaces;

namespace WebApplication3.Services.Implements
{
    public class SubjectService : ISubjectService
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public SubjectService(ILogger<StudentService> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public PageResultDto<List<SubjectWithPointDto>> GetAll(FilterDto input)
        {
            var subjectQuery = _dbContext.Subjects.AsQueryable();
            if (input.Keyword != null)
            {
                subjectQuery = subjectQuery.Where(s => s.SubjectName != null &&
                s.SubjectName.ToLower().Contains(input.Keyword));
                //or s.Name?.Contains(input.Keyword) ?? false
            }
            int totalItem = subjectQuery.Count();
            subjectQuery = subjectQuery.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize);

            var list = new List<SubjectWithPointDto>();
            list = subjectQuery.Select(o => new SubjectWithPointDto
            {
                Id = o.Id,
                NumberOfCredit = o.NumberOfCredit,
                SubjectCode = o.SubjectCode,
                SubjectName = o.SubjectName 
            }).ToList();

            foreach (var subject in list)
            {
                if (_dbContext.StudentSubjects.Any(ss => ss.SubjectId == subject.Id))
                {
                    subject.PointAvg = _dbContext.StudentSubjects.Where(ss => ss.SubjectId == subject.Id).Average(ss => ss.Point);
                }
                else
                {
                    subject.PointAvg = 0;
                }
            }
            int subjectId = 1;
            float maxPoint = _dbContext.StudentSubjects.Where(ss => ss.SubjectId == subjectId).Max(o => o.Point);

            //_dbContext.StudentSubject.Where(ss => ss.SubjectId == subjectId && ss.Point == maxPoint)
            //    .Join(_dbContext.Students, ss => ss.StudentId, s => s.Id, (ss, s) => new
            //    {
            //        s.StudentCode,
            //        s.Name,
            //        ss.Point
            //    });

            //var result = 

            var test = from studentSubject in _dbContext.StudentSubjects.Where(ss => ss.SubjectId == subjectId && ss.Point == maxPoint)
                       join student in _dbContext.Students on studentSubject.StudentId equals student.Id
                       select new //classDto
                       {
                           student.StudentCode,
                           student.Name,
                           studentSubject.Point
                       };

            var test2 = test.ToList();

            return new PageResultDto<List<SubjectWithPointDto>>
            {
                Items = list,
                TotalItem = totalItem,
            };
        }
        public void Create(CreateSubjectDto input)
        {
            if (_dbContext.Subjects.Any(s => s.SubjectCode == input.SubjectCode))
            {
                throw new UserFriendlyException($"Ma mon hoc \"{input.SubjectCode}\" da ton tai");
            }
            _dbContext.Subjects.Add(new Subject
            {

                SubjectCode = input.SubjectCode,
                SubjectName = input.SubjectName,
                NumberOfCredit = input.NumberOfCredit

            });
            _dbContext.SaveChanges();
        }
        public void Update(UpdateSubjectDto input)
        {
            var subject = _dbContext.Subjects.FirstOrDefault(p => p.Id == input.SubjectId);
            if (subject != null)
            {
                subject.SubjectCode = input.SubjectCode;
                subject.SubjectName = input.SubjectName;
                subject.NumberOfCredit = input.NumberOfCredit;
                _dbContext.SaveChanges();
            }
            else
                throw new UserFriendlyException("Khong tim thay mon hoc");
        }
        public Subject GetbyId(int id)
        {
            var subject = _dbContext.Subjects.FirstOrDefault((p) => p.Id == id);
            return subject;
        }
        public void Delete(int id)
        {
            var subject = _dbContext.Subjects.FirstOrDefault((p) => p.Id == id);
            if (subject != null)
            {
                _dbContext.Subjects.Remove(subject);
                _dbContext.SaveChanges();
            }
            else
                throw new UserFriendlyException("Khong tim thay mon hoc");
        }


    }
}
