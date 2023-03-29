using Filter_DCSon.DbContexts;
using Filter_DCSon.Dto;
using Filter_DCSon.Entities;

namespace Filter_DCSon.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ILogger _logger;
        private readonly MyDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public SubjectService(ILogger<SubjectService> logger, MyDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // get all
        public List<Subject> GetAll()
        {
            var result = _dbContext.Subjects;
            return result.ToList();
        }

        // get all with page
        public PageResultSubjectDto GetAllWithPageSubject(SubjectFilterDto input)
        {
            //kiểm tra Name có chứa keyword không
            var classroomQuery = _dbContext.Subjects.AsQueryable();

            if (input.Keyword != null)
            {
                classroomQuery = classroomQuery.Where(s => s.Name != null && s.Name.ToLower().Contains(input.Keyword));
            }
            int totalItem = classroomQuery.Count();

            classroomQuery = classroomQuery.Skip(input.PageSize * (input.PageIndex - 1)).Take(input.PageSize);
            return new PageResultSubjectDto
            {
                Items = classroomQuery.ToList(),
                TotalItem = totalItem
            };
        }

        //thêm
        public void CreateSubject (CreateSubjectDto input)
        {
            _dbContext.Subjects.Add(new Subject
            {
                Name = input.Name,
                SubjectCode = input.SubjectCode,
                NumberCredits = input.NumberCredits,
            });
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateSubjectDto input)
        {
            var result = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Name = input.Name;
                result.SubjectCode = input.SubjectCode;
                result.NumberCredits = input.NumberCredits;
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);
            _dbContext.Subjects.Remove(result);
            _dbContext.SaveChanges();
        }

        public Subject GetById(int id)
        {
            var result = _dbContext.Subjects.FirstOrDefault(x => x.Id == id);
            return result;
        }

    }
}
