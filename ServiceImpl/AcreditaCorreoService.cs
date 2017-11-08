using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;
using webapi2Tarea.IService;
using webapi2Tarea.Repository;

namespace webapi2Tarea.ServiceImpl
{
    public class AcreditaCorreoService : IAcreditaCorreosService
    {
       private SGR4DbContext db = new SGR4DbContext();
        public IEnumerable<Acredita_Correos> findAll()
        {
            return db.Courses;
        }
    }
}