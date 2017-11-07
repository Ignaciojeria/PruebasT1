using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;
using webapi2Tarea.IService;
using webapi2Tarea.Models;
using webapi2Tarea.Repository;

namespace webapi2Tarea.ServiceImpl
{
    public class UserService :IUserService
    {
        UserRepository userContext = PDbContext.getUserDBContext();
        public List<User> findAll()
        {
            return userContext.findAll();
        }

        public User findByUserModel(UserModel userModel)
        {
            try {
            return userContext.findByUserModel(userModel);
            }
            catch
            {
                return null;
            }
        }

        //Usuario hardCodeado
        public User GetUserByCredentials(string email, string password)
        {
            if (email.Equals("admin") && password.Equals("admin"))
                return new User() { Id = "1", Email = "email@domain.com", Password = "password", Name = "Ole Petter Dahlmann" };
            else return null;
        }

    }
}