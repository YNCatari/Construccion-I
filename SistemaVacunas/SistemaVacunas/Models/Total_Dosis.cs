namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Total_Dosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Total_Dosis()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int Id_totaldosis { get; set; }

        public int? Totaldosis { get; set; }

        public int? Totalingresadas { get; set; }

        public int? Id_dosis { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public virtual Dosis Dosis { get; set; }
    }
}
