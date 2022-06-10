/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Tipo Dosis - 8*/
namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Tipo_Dosis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Dosis()
        {
            Citas = new HashSet<Citas>();
            Dosis = new HashSet<Dosis>();
        }

        [Key]
        public int Id_tipodosis { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombre de  tipo dosis")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar descripcion de dosis")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dosis> Dosis { get; set; }

        //Listar Tipo Dosis
        public List<Tipo_Dosis> Listar()
        {
            var rol = new List<Tipo_Dosis>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Tipo_Dosis.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Obtener Tipo Dosis
        public Tipo_Dosis Obtener(int id)
        {
            var rol = new Tipo_Dosis();
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Tipo_Dosis
                        .Where(x => x.Id_tipodosis == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Buscar Tipo Dosis
        public List<Tipo_Dosis> Buscar(string criterio)
        {
            var rol = new List<Tipo_Dosis>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacunas())
                {
                    rol = db.Tipo_Dosis
                        .Where(x => x.Descripcion.Contains(criterio) || x.Estado == estado || x.Nombre.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rol;
        }
        //Registrar Dosis
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_tipodosis > 0)
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
