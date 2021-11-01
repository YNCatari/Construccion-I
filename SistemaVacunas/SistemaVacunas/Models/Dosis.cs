namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Dosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dosis()
        {
            Total_Dosis = new HashSet<Total_Dosis>();
        }

        [Key]
        public int Id_dosis { get; set; }
        [Required]
        [StringLength(50)]
        public string Cantidad { get; set; }
        [Required]
        [StringLength(50)]
        public string Observaciones { get; set; }
        [Required]
        [StringLength(50)]
        public string Fecha { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        public int? Id_tipodosis { get; set; }

        public virtual Tipo_Dosis Tipo_Dosis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Total_Dosis> Total_Dosis { get; set; }

        //listar dosis
        public List<Dosis> Listar()
        {
            var dosis = new List<Dosis>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    dosis = db.Dosis.Include("Tipo_Dosis").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dosis;
        }
        //guardar dosis
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.Id_dosis > 0)
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
        //Obtener dosis
        public Dosis Obtener(int id)
        {
            var dosis = new Dosis();
            try
            {
                using (var db = new ModelVacuna())
                {
                    dosis = db.Dosis
                        .Where(x => x.Id_dosis == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dosis;
        }
        //Buscar dosis
        public List<Dosis> Buscar(string criterio)
        {
            var dosis = new List<Dosis>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    dosis = db.Dosis
                        .Where(x => x.Cantidad.Contains(criterio) || x.Observaciones.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dosis;
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    db.Entry(this).State = EntityState.Deleted;
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
