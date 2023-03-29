using ExWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        [HttpGet]
        public IActionResult GetAll() 
            => Ok(new
            {
                Students = students
            });

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Student = student,
                });
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            /*var std = new Student
            {
                Id = (int)student.Id,
                Name = student.Name,
                StudentCode = (int)student.StudentCode,
                BirthDay = student.BirthDay
            };*/
            students.Add(student);
            return Ok(new
            {
                Success = true,
                Data = student
            });
        }

        /// <summary>
        /// Sua thong tin sinh vien theo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentEdit"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Student studentEdit)
        {
            try
            {
                // LINQ [Object] Query
                var std = students.SingleOrDefault(s => s.Id == id);
                if (std == null)
                {
                    return NotFound();
                }

                if (id != std.Id)
                {
                    return BadRequest();
                }
                // Update
                std.Name = studentEdit.Name;
                std.StudentCode = studentEdit.StudentCode;
                std.BirthDay = studentEdit.BirthDay;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Xoa thong tin cua sinh vien theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                // LINQ [Object] Query
                var std = students.SingleOrDefault(s => s.Id == id);
                if (std == null)
                {
                    return NotFound();
                }
                // Update
                students.Remove(std);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

       /* [HttpGet]
        public IActionResult SortByName()
        {
            students.OrderBy(s => s.Name).ThenBy(s => s.Id);
            return Ok(new
            {
                Student = students
            });

        }

        [HttpGet]
        public IActionResult NumberOfStudets()
        => Ok(new
        {
            Count = students.Count,
        });*/
    }
}
