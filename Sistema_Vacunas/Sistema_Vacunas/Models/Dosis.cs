namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dosis()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_dosis { get; set; }

        [Required]
        [StringLength(255)]
        public string cantidad { get; set; }

        [Required]
        [StringLength(255)]
        public string observaciones { get; set; }

        [Required]
        [StringLength(20)]
        public string fecha { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int id_tipodosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public virtual Tipo_Dosis Tipo_Dosis { get; set; }
    }
}
