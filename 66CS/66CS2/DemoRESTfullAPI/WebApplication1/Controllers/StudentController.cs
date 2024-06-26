﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();
        private static int _id = 0;

        public StudentController()
        {
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDto input) //tại sao request body lại binding vào hàm này được ?
        {
            //if (string.IsNullOrEmpty(input.Name))
            //{
            //    return BadRequest("Tên không hợp lệ"); //http status 400
            //}
            var student = new Student
            {
                Id = ++_id,
                Name = input.Name,
                StudentCode = input.StudentCode,
                DateOfBirth = input.DateOfBirth,
                IsDeleted = false
            };

            _students.Add(student);
            //các hàm đều trả về các đối tượng implement interface IActionResult
            return Ok(student); //http status code 200
        }

        [HttpGet("get-all")]
        public IActionResult GetStudents()
        {
            //sử dụng hàm select (linq)
            var result = _students.Where(s => !s.IsDeleted).Select(s => new StudentDto
            {
                Id = s.Id,
                Name = s.Name,
                StudentCode = s.StudentCode,
                DateOfBirth = s.DateOfBirth,
            });
            return Ok(result);
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            //sử dụng hàm firstOrDefault
            var studentFind = _students.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            if (studentFind == null)
            {
                return BadRequest(new { message = $"Không tìm thấy sinh viên có id {id}" });
            }
            return Ok(new StudentDto
            {
                Id = studentFind.Id,
                Name = studentFind.Name,
                StudentCode = studentFind.StudentCode,
                DateOfBirth = studentFind.DateOfBirth,
            });
        }

        [HttpPut("update")]
        public IActionResult UpdateStudent(UpdateStudentDto input)
        {
            var studentFind = _students.Find(s => s.Id == input.Id && !s.IsDeleted);
            if (studentFind == null)
            {
                return BadRequest(new ApiResponse { Message = $"Không tìm thấy sinh viên có id {input.Id}" });
            }

            studentFind.StudentCode = input.StudentCode;
            studentFind.Name = input.Name;
            studentFind.DateOfBirth = input.DateOfBirth;
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentFind = _students.Find(s => s.Id == id && !s.IsDeleted);
            if (studentFind == null)
            {
                return BadRequest(new ApiResponse { Message = $"Không tìm thấy sinh viên có id {id}" });
            }
            studentFind.IsDeleted = true;
            //_students.Remove(studentFind);
            return Ok();
        }
    }
}
