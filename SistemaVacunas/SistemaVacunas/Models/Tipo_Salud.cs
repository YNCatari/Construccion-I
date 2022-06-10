/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: tipo Salud(Tipo Centro) - 11*/
namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Tipo_Salud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Salud()
        {
            Centro = new HashSet<Centro>();
        }

        [Key]
        public int Id_tiposalud { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombre de un centro salud")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar la descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Centro> Centro { get; set; }
        //Listar Tipo Salud
        public List<Tipo_Salud> Listar()
        {
            var tipo = new List<Tipo_Salud>();
            try
            {
                using (var db = new ModelVacunas())
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
        //Obtener Tipo Salud
        public Tipo_Salud Obtener(int id)
        {
            var tipo = new Tipo_Salud();
            try
            {
                using (var db = new ModelVacunas())
                {
                    tipo = db.Tipo_Salud
                        .Where(x => x.Id_tiposalud == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo;
        }
        //Buscar Tipo Salud
        public List<Tipo_Salud> Buscar(string criterio)
        {
            var tipo = new List<Tipo_Salud>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacunas())
                {
                    tipo = db.Tipo_Salud
                        .Where(x => x.Nombre.Contains(criterio) || x.Descripcion.Contains(criterio) || x.Estado == estado)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return tipo;
        }
        //Registrar Tipo Salud
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_tiposalud > 0)
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
