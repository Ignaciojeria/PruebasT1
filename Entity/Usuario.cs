namespace webapi2Tarea.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rutEmpleado { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(50)]
        public string usuario { get; set; }

        [Required]
        [StringLength(45)]
        public string contrasena { get; set; }

        [StringLength(50)]
        public string idPregunta { get; set; }

        [StringLength(50)]
        public string respuesta { get; set; }

        public int? telefono { get; set; }

        [StringLength(50)]
        public string correo { get; set; }

        public string linkRecuperacion { get; set; }

        public int intentosLogin { get; set; }

        public int estado { get; set; }

        [Required]
        [StringLength(50)]
        public string usucre { get; set; }

        public DateTime feccre { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        [StringLength(250)]
        public string Path { get; set; }
    }
}
