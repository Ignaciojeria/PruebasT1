namespace webapi2Tarea.Repository
{
    using Entity;
    using System;
    using System.Data.Entity;

    using System.Linq;

    public partial class SGR4Context : DbContext
    {
        public SGR4Context()
            : base("name=SGR4Context")
        {
        }

        public virtual DbSet<Acredita_Nacionalidad> Acredita_Nacionalidad { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        /*
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Acredita_Correos>()
                        .Property(e => e.CustomHTML)
                        .IsUnicode(false);

                    modelBuilder.Entity<Acredita_Correos>()
                        .Property(e => e.Recipients)
                        .IsUnicode(false);
                }
            }*/
    }
}
