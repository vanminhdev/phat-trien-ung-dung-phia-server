using DemoWebAPI.Dto;
using DemoWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();
        private static int _id = 0;

        /// <summary>
        /// Thêm user
        /// </summary>
        /// <param name="input"></param>
        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserDto input)
        {
            try
            {
                _users.Add(new User
                {
                    Id = ++_id,
                    Name = input.Name,
                    UserName = input.UserName,
                    Password = input.Password
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cập nhật thông tin user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(int id, UpdateUserDto input)
        {
            try
            {
                var userFind = _users.FirstOrDefault(u => u.Id == id);
                if (userFind == null)
                {
                    //Http status code: 404
                    return NotFound(new { message = $"Không tìm thấy user có Id = {id}" });
                }
                userFind.Name = input.Name;
                userFind.UserName = input.UserName;
                userFind.Password = input.Password;
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Xem thông tin 1 user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            User userFind = _users.FirstOrDefault(u => u.Id == id);
            if (userFind == null) //kiểm tra dữ liệu
            {
                return NotFound(new { message = $"Không tìm thấy user có Id = {id}" });//Http status code: 404
            }
            return Ok(userFind);
        }

        /// <summary>
        /// Danh sách user
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_users);
        }

        /// <summary>
        /// Xoá user theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userFind = _users.FirstOrDefault(u => u.Id == id);
                if (userFind == null)
                {
                    return NotFound(new { message = $"Không tìm thấy user có Id = {id}" });
                }
                _users.Remove(userFind);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
