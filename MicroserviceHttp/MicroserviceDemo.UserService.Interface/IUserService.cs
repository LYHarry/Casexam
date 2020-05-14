using MicroserviceDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.UserService.Interface
{
    public interface IUserService
    {
        UserEntity GetUserInfo(int id);

        List<UserEntity> GetAllUsers();

    }
}
