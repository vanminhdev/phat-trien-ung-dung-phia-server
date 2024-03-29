﻿using WebApplication1.DbContexts;
using WebApplication1.Dto.Student;
using WebApplication1.Entities;
using WebApplication1.Exceptions;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateStudentDto input)
        {
            // thêm sinh viên vào list
            _context.Students.Add(new Student
            {
                Id = ++_context.StudentId,
                Name = input.Name,
                Age = input.Age,
            });
        }

        public void Update(UpdateStudentDto input)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == input.Id);
            if (student == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input.Id}");
            }
            student.Name = input.Name;
            student.Age = input.Age;
        }

        public List<StudentDto> GetAll()
        {
            var results = new List<StudentDto>();
            foreach (var student in _context.Students)
            {
                results.Add(new StudentDto 
                { 
                    Id = student.Id,
                    Name = student.Name,
                    Age = student.Age
                });
            }
            return results;
        }
    }
}
