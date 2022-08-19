
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
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult GetAll()
        { 
            return Ok(new
            {
                Users = users
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return NotFound();  // 404
                }
                // 200
                return Ok(new
                {
                    User = user,
                });
            }
            catch
            {
                return BadRequest();  // 400
            }

        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var usr = new User
            {
                Id = users.Count + 1,
                Name = user.Name,
                UserName = user.UserName,
                Password = user.Password
            };
            users.Add(usr);
            return Ok(new
            {
                Success = true,
                Data = usr
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, User userEdit)
        {
            try
            {
                // LINQ [Object] Query
                var std = users.FirstOrDefault(u => u.Id == id);
                if (std == null)
                {
                    return NotFound();
                }

                if (id != std.Id)
                {
                    return BadRequest();
                }
                // Update
                std.Name = userEdit.Name;
                std.UserName = userEdit.UserName;
                std.Password = userEdit.Password;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Xoa thong tin cua nguoi dung theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                // LINQ [Object] Query
                var usr = users.FirstOrDefault(u => u.Id == id);
                if (usr == null)
                {
                    return NotFound();
                }
                // Update
                users.Remove(usr);

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
