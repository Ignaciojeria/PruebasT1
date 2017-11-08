using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webapi2Tarea.Entity;

namespace webapi2Tarea.Repository
{
    public class SGR4DbContext : DbContext
    {
        public SGR4DbContext():base("Data Source = 192.168.21.116; AttachDbFileName=|DataDirectory|\DatabaseFileName.mdf;InitialCatalog=DatabaseName;Integrated Security = True; MultipleActiveResultSets=True") { }
        public virtual DbSet<Acredita_Correos> Courses { get; set; }
    }
}