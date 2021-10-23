namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    public partial class Tipo_Dosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Dosis()
        {
            Dosis = new HashSet<Dosis>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_tipodosis { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dosis> Dosis { get; set; }

        public List<Tipo_Dosis> Listar()
        {
            var tipo = new List<Tipo_Dosis>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Dosis.ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return tipo;
        }
        public Tipo_Dosis Obtener(int id)
        {
            var tipo = new Tipo_Dosis();
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Dosis
                        .Where(x => x.id_tipodosis == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return tipo;
        }
        public List<Tipo_Dosis> Buscar(string criterio)
        {
            var tipo = new List<Tipo_Dosis>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacuna())
                {
                    tipo = db.Tipo_Dosis
                        .Where(x => x.nombre.Contains(criterio) || x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception )
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
                    if (this.id_tipodosis > 0)
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
            catch (Exception )
            {
                throw;
            }
        }
      

    }
}
