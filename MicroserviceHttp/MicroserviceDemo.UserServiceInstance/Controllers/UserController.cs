using MicroserviceDemo.Model;
using MicroserviceDemo.UserService.Interface;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
    }
}
