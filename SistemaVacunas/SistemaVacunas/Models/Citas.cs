namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Citas
    {
        [Key]
        public int Id_citas { get; set; }
        [Required]
        [StringLength(50)]
        public string Lugarvacunacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10)]
        public string Fecha { get; set; }
        [Required]
        [StringLength(10)]
        public string Hora { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        public int? Id_paciente { get; set; }

        public int? Id_medico { get; set; }

        public int? Id_centro { get; set; }

        public int? Id_totaldosis { get; set; }

        public int? Check1 { get; set; }

        public int? Check2 { get; set; }

        public virtual Centro Centro { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Total_Dosis Total_Dosis { get; set; }
    }
}
