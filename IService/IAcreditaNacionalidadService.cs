using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi2Tarea.Entity;

namespace webapi2Tarea.IService
{
    public interface IAcreditaNacionalidadService
    {
        IEnumerable<Acredita_Nacionalidad> findAll();
    }
}
