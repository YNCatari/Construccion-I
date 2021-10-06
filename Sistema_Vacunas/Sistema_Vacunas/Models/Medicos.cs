namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medicos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicos()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_medico { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string sexo { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string turno_mañana { get; set; }

        [Required]
        [StringLength(255)]
        public string contraseña { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int id_rol { get; set; }

        public int id_horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
