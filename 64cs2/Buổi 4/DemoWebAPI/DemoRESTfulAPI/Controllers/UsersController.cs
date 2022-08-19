using DemoRESTfulAPI.Models;
using DemoRESTfulAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DemoRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<Users> _users;

        public UsersController()
        {
            _users = new List<Users>();
            _users.Add(new Users
            {
                Id = 1,
                UserName = "abc1",
                Email = "abc1@gmail.com",
                DateOfBirth = new DateTime(2022, 1, 1),
                Phone = "0123456789"
            });

            _users.Add(new Users
            {
                Id = 2,
                UserName = "abc2",
                Email = "abc2@gmail.com",
                DateOfBirth = new DateTime(2022, 1, 1),
                Phone = "0123456789"
            });
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_users);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateUserDto input)
        {
            _users.Add(new Users
            {
                Id = input.Id,
                UserName = input.UserName,
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                DateOfBirth = input.DateOfBirth
            });
            return Ok();
        }
    }
}
