/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Rol - 3*/
namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Medico = new HashSet<Medico>();
            Usuarios = new HashSet<Usuarios>();
        }

        [Key]
        public int Id_rol { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios { get; set; }

        //Listar Rol
        public List<Rol> Listar()
        {
            var rol = new List<Rol>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Rol.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Obtener Rol
        public Rol Obtener(int id)
        {
            var rol = new Rol();
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Rol
                        .Where(x => x.Id_rol == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Buscar Rol
        public List<Rol> Buscar(string criterio)
        {
            var rol = new List<Rol>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Rol
                        .Where(x => x.Descripcion.Contains(criterio) || x.Estado == estado)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Registrar Rol
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_rol > 0)
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
