using DemoWebAPI.Dto;
using DemoWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        /// <summary>
        /// Tìm user theo id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            User userFind = _users.FirstOrDefault(u => u.Id == id);
            if (userFind == null) //kiểm tra dữ liệu
            {
                return NotFound();//Http status code: 404
            }
            return Ok(userFind); //Http status code: 200
        }

        /// <summary>
        /// Thêm user.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserDto input)
        {
            try
            {
                _users.Add(new User
                {
                    Id = _users.Count + 1,
                    Name = input.Name,
                    UserName = input.UserName,
                    Password = input.Password
                });
                return Ok(); //Http status code: 200
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cập nhật thông tin user.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto input)
        {
            try
            {
                var userFind = _users.FirstOrDefault(u => u.Id == id);
                if (userFind == null)
                {
                    return NotFound();//Http status code: 404
                }
                userFind.Name = input.Name;
                userFind.UserName = input.UserName;
                userFind.Password = input.Password;
                return Ok(); //Http status code: 200
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Hiển thị danh sách user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_users);
        }

        /// <summary>
        /// Xoá user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var userFind = _users.FirstOrDefault(u => u.Id == id);
                if (userFind == null)
                {
                    return NotFound("Không tìm thấy user");//Http status code: 404
                }
                _users.Remove(userFind);
                return Ok(); //200
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
