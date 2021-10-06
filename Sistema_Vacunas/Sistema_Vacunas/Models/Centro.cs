namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Centro")]
    public partial class Centro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Centro()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_centro { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string calle { get; set; }

        [Required]
        [StringLength(50)]
        public string ciudad { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        [Required]
        [StringLength(50)]
        public string distrito { get; set; }

        [Required]
        [StringLength(50)]
        public string codigopostal { get; set; }

        public int id_tiposalud { get; set; }

        public virtual Tipo_Salud Tipo_Salud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }
    }
}
