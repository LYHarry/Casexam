using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceDemo.WebApi.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("UserInfo")]
        public string GetUserInfo()
        {
            return "UserController.GetUserInfo";
        }
    }
}
