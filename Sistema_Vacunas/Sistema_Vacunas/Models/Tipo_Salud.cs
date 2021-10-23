namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class Tipo_Salud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Salud()
        {
            Centro = new HashSet<Centro>();
        }

        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tiposalud { get; set; }

        [Required]
        [StringLength(255)]
        public string nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Centro> Centro { get; set; }

        public List<Tipo_Salud> Listar()
        {
            var tipo = new List<Tipo_Salud>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Salud.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo;
        }
        public Tipo_Salud Obtener(int id)
        {
            var tipo = new Tipo_Salud();
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Salud
                        .Where(x => x.id_tiposalud == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo;
        }
        public List<Tipo_Salud> Buscar(string criterio)
        {
            var tipo = new List<Tipo_Salud>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Salud
                        .Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_tiposalud > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
