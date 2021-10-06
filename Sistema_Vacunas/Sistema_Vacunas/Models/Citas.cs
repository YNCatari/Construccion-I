namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Citas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_citas { get; set; }

        [Required]
        [StringLength(100)]
        public string lugarvacunacion { get; set; }

        [Required]
        [StringLength(255)]
        public string direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string horario_atencion { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int id_pacientes { get; set; }

        public int id_medico { get; set; }

        public int id_centro { get; set; }

        public int id_dosis { get; set; }

        public int id_check1 { get; set; }

        public int id_check2 { get; set; }

        public virtual Centro Centro { get; set; }

        public virtual Check1 Check1 { get; set; }

        public virtual Check2 Check2 { get; set; }

        public virtual Pacientes Pacientes { get; set; }

        public virtual Medicos Medicos { get; set; }

        public virtual Dosis Dosis { get; set; }
    }
}
