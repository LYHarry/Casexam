using MicroserviceDemo.Model;
using MicroserviceDemo.Repository.Interface;
using MicroserviceDemo.UserService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroserviceDemo.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;

        public UserService(IUserRepository userRepository)
        {
            _user = userRepository;
        }

        public UserEntity GetUserInfo(int id)
        {
            return _user.GetUserInfo(id);
        }

        public List<UserEntity> GetAllUsers()
        {
            return _user.GetAllUsers();
        }
    }
}
