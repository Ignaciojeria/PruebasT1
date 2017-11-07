using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi2Tarea.Entity;
using webapi2Tarea.ServiceImpl;

namespace webapi2Tarea.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public List<User> Get()
        {
            return new UserService().findAll();
        }
    }
}
