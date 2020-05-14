using MicroserviceDemo.Model;
using MicroserviceDemo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroserviceDemo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UserEntity> _userEntities;

        public UserRepository()
        {
            _userEntities = new List<UserEntity>();
            _userEntities.Add(new UserEntity()
            {
                ID = 1,
                Name = "joke",
                Age = 12,
                CreateDate = DateTime.Now
            });
            _userEntities.Add(new UserEntity()
            {
                ID = 2,
                Name = "harry",
                Age = 25,
                CreateDate = DateTime.Now
            });
            _userEntities.Add(new UserEntity()
            {
                ID = 3,
                Name = "meia",
                Age = 30,
                CreateDate = DateTime.Now
            });
            _userEntities.Add(new UserEntity()
            {
                ID = 4,
                Name = "eike",
                Age = 20,
                CreateDate = DateTime.Now
            });
            _userEntities.Add(new UserEntity()
            {
                ID = 5,
                Name = "yaie",
                Age = 23,
                CreateDate = DateTime.Now
            });

        }

        public UserEntity GetUserInfo(int id)
        {
            return _userEntities.FirstOrDefault(p => p.ID == id);
        }

        public List<UserEntity> GetAllUsers()
        {
            return _userEntities;
        }
    }
}
