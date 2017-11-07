using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;

namespace webapi2Tarea.Repository
{
    public class UserRepository
    {
        private List<User> users;

        //Simularà un mock de usuarios!! Esta informaciòn debe de ser proveida por la bdd
        private static UserRepository userRepository = new UserRepository();

        private UserRepository()
        {
            users = new List<User>();
            mock();
        }

        private void mock()
        {
            users.Add(new User() { Id = 1, Email = "Ignaciovl.j@gmail.com", Password = "user", Name = "Ignacio" });
            users.Add(new User() { Id = 2, Email = "admin@domain.com", Password = "admin", Name = "Administrador" });
        }

        public static UserRepository getInstance()
        {
            return userRepository;
        }

        public List<User> findAll()
        {
            return users;
        }
    }
}