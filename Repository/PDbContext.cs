using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi2Tarea.Repository
{
    public class PDbContext
    {
        public static UserRepository getUserDBContext()
        {
            return UserRepository.getInstance();
        }

    }
}