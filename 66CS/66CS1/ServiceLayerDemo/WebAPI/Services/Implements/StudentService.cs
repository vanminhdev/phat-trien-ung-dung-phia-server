﻿using WebAPI.DbContexts;
using WebAPI.Dtos.Students;
using WebAPI.Entities;
using WebAPI.Exceptions;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Student CreateStudent(CreateStudentDto input)
        {
            var student = new Student
            {
                //Id = ++_dbContext.StudentId,
                Name = input.Name,
                DateOfBirth = input.DateOfBirth,
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        public void UpdateStudent(UpdateStudentDto student)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == student.Id);
            if (findStudent == null)
            {
                //báo lỗi
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id là {student.Id}");
            }
            else
            {
                findStudent.Name = student.Name;
                findStudent.DateOfBirth = student.DateOfBirth;
            }
            _dbContext.SaveChanges();

            //có thêm ngoại lệ
            // throw new Ex
        }

        public void DeleteStudent(int id)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent == null)
            {
                //báo lỗi
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id là {id}");
            }
            _dbContext.Students.Remove(findStudent);
            _dbContext.SaveChanges();
        }
    }
}
