using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;
using webapi2Tarea.IService;
using webapi2Tarea.Repository;

namespace webapi2Tarea.ServiceImpl
{
    public class AcreditaNacionalidadService : IAcreditaNacionalidadService
    {
       private SGR4Context db = new SGR4Context();

        IEnumerable<Entity.Acredita_Nacionalidad> IAcreditaNacionalidadService.findAll()
        {
            return db.Acredita_Nacionalidad;
        }
    }
}