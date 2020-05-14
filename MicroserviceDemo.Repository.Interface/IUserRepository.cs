using MicroserviceDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.Repository.Interface
{
    public interface IUserRepository
    {
        UserEntity GetUserInfo(int id);

        List<UserEntity> GetAllUsers();
    }
}
