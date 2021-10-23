namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Medicos = new HashSet<Medicos>();
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_rol { get; set; }

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
        public virtual ICollection<Medicos> Medicos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }

        public List<Rol> Listar()
        {
            var rol = new List<Rol>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    rol = db.Rol.ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return rol;
        }
        public Rol Obtener(int id)
        {
            var rol = new Rol();
            try
            {
                using (var db = new ModelVacuna())
                {
                    rol = db.Rol
                        .Where(x => x.id_rol == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return rol;
        }
        public List<Rol> Buscar(string criterio)
        {
            var rol = new List<Rol>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacuna())
                {
                    rol = db.Rol
                        .Where(x => x.descripcion.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return rol;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_rol > 0)
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
