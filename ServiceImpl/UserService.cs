using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;
using webapi2Tarea.Repository;

namespace webapi2Tarea.ServiceImpl
{
    public class UserService
    {
        UserRepository userContext = PDbContext.getUserDBContext();
        public List<User> findAll()
        {
            return userContext.findAll();
        }
    }
}