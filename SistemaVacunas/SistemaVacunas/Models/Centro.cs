namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Centro")]
    public partial class Centro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Centro()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int Id_centro { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        public string Calle { get; set; }
        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }
        [Required]
        [StringLength(50)]
        public string Distrito { get; set; }
        [Required]
    
        [StringLength(50)]
        public string Codigo { get; set; }

        public int? Id_tiposalud { get; set; }

        public virtual Tipo_Salud Tipo_Salud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }


        //listar Centro
        public List<Centro> Listar()
        {
            var centros = new List<Centro>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    centros = db.Centro.Include("Tipo_Salud").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return centros;
        }
        //guardar Centro
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.Id_centro > 0)
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
        //Obtener centro
        public Centro Obtener(int id)
        {
            var centros = new Centro();
            try
            {
                using (var db = new ModelVacuna())
                {
                    centros = db.Centro
                        .Where(x => x.Id_centro == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return centros;
        }
        //Buscar centro
        public List<Centro> Buscar(string criterio)
        {
            var centros = new List<Centro>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    centros = db.Centro
                        .Where(x => x.Nombre.Contains(criterio) || x.Ciudad.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return centros;
        }


    }
}
