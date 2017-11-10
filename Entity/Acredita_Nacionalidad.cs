using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapi2Tarea.Entity
{
    public class Acredita_Nacionalidad
    {
        [Key]
        public int IdNacionalidad { get; set; }
        public string Nacionalidad { get; set; }
    }
}