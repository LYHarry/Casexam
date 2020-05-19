using MicroserviceDemo.Model;
using MicroserviceDemo.UserService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.UserServiceInstance.Controllers
{
    [Route("api/UserService")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _config = configuration;
        }

        [HttpGet]
        [Route("User")]
        public UserEntity GetUserInfo(int id)
        {
            return _userService.GetUserInfo(id);
        }

        [HttpGet]
        [Route("AllUser")]
        public List<UserEntity> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("Message")]
        public string GetMessage()
        {
            var msg = $"UserService:{_config["port"]} Invoke {DateTime.Now:yyyy-MM-dd HH:mm:ss fff}";

            Console.WriteLine(msg);

            return msg;
        }
    }
}
