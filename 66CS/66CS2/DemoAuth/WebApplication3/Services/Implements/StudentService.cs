﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplication.DbContexts;
using WebApplication.Dtos.Shared;
using WebApplication.Dtos.Students;
using WebApplication.Entities;
using WebApplication.Exceptions;
using WebApplication.Services.Interfaces;
using WebApplication.Utils;

namespace WebApplication.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentService(ILogger<StudentService> logger, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public PageResultDto<List<StudentDto>> GetAll(FilterDto input)
        {
            var studentQuery = _dbContext.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                DateOfBirth = s.DateOfBirth,
                StudentCode = s.StudentCode
            });
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                studentQuery = studentQuery.Where(s => s.Name.ToLower().Contains(input.Keyword));
                //or s.Name?.Contains(input.Keyword) ?? false
            }
            int totalItem = studentQuery.Count();
            studentQuery = studentQuery.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize);

            return new PageResultDto<List<StudentDto>>
            {
                Items = studentQuery.ToList(),
                TotalItem = totalItem,
            };
        }

        public void Create(CreateStudentDto input)
        {
            int currentUserId = CommonUtils.GetCurrentUserId(_httpContextAccessor);
            if (_dbContext.Students.Any(s => s.StudentCode == input.StudentCode))
            {
                throw new UserFriendlyException($"Mã sinh viên \"{input.StudentCode}\" đã tồn tại");
            }
            _dbContext.Students.Add(new Student
            {
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth,
            });
            _dbContext.SaveChanges();
        }

        public void Update(UpdateStudentDto input)
        {
            var student = _dbContext.Students.FirstOrDefault(p => p.Id == input.StudentId);
            if (student != null)
            {
                //cách 1:
                var count = _dbContext.Students
                    .Where(s => s.StudentCode == input.StudentCode && s.Id != input.StudentId)
                    .Count();

                if (count > 0)
                {
                    //báo lỗi
                }

                //cách 2
                if (_dbContext.Students
                    .Any(s => s.StudentCode == input.StudentCode && s.Id != input.StudentId))
                {
                    //báo lỗi
                }

                student.StudentCode = input.StudentCode;
                student.DateOfBirth = input.DateOfBirth;
                student.Name = input.Name;
                _dbContext.SaveChanges();
            }
            else
                throw new UserFriendlyException("Không tìm thấy sinh viên");
        }

        public Student GetbyId(int id)
        {
            var student = _dbContext.Students.FirstOrDefault((p) => p.Id == id);
            return student;
        }

        public void Delete(int id)
        {
            var student = _dbContext.Students.FirstOrDefault((p) => p.Id == id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
            else
                throw new UserFriendlyException("Không tìm thấy sinh viên");
        }
        public void AddSubjectForStudent(int subjectId, int studentId)
        {
            if (_dbContext.StudentSubjects
                .Any(sc => sc.StudentId == studentId && sc.SubjectId == subjectId))
            {
                throw new UserFriendlyException("Sinh viên đã thêm môn học");
            }
            var subject = _dbContext.Subjects.FirstOrDefault(c => c.Id == subjectId);
            if (subject == null)
            {
                throw new UserFriendlyException("Không tìm thấy môn học");
            }
            var student = _dbContext.Students.FirstOrDefault(c => c.Id == studentId);
            if (student == null)
            {
                throw new UserFriendlyException("Không tìm thấy sinh viên");
            }
            _dbContext.StudentSubjects.Add(new StudentSubject
            {
                SubjectId = subjectId,
                StudentId = studentId,
            });
            _dbContext.SaveChanges();
        }

        public void DeleteSubject(int subjectId, int studentId)
        {
            var subject = _dbContext.StudentSubjects
                .FirstOrDefault(s => s.SubjectId == subjectId && s.StudentId == studentId);
            if (subject == null)
                throw new UserFriendlyException("Sinh viên không theo học môn học này");
            _dbContext.StudentSubjects.Remove(subject);
        }

        public void UpdatePoint(UpdatePointDto input)
        {
            var studentSubject = _dbContext.StudentSubjects
                .FirstOrDefault(s => s.SubjectId == input.SubjectId && s.StudentId == input.StudentId);
            if (studentSubject != null)
            {
                studentSubject.Point = input.Point;
                _dbContext.SaveChanges();
            }
            else
                throw new UserFriendlyException("Không tìm thấy sinh viên");

        }
        public List<StudentSubjectDto> GetListPointOfStudent(int studentId)
        {
            var points = from studentSubject in _dbContext.StudentSubjects
                       join subject in _dbContext.Subjects on new { studentSubject.SubjectId, studentSubject.StudentId } equals new { SubjectId = subject.Id, StudentId = studentId }
                       select new StudentSubjectDto
                       {
                           SubjectName = subject.SubjectName,
                           Point = studentSubject.Point
                       };

            return points.ToList();
        }

    }
}
