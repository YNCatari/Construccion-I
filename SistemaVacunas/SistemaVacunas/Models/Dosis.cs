namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Dosis
    {
        [Key]
        public int Id_dosis { get; set; }
        [Required(ErrorMessage = "Debe ingresar cantidad vacunas")]
        [StringLength(50)]
        public string Cantidad { get; set; }
        [Required(ErrorMessage = "Debe ingresar observaciones o detalles")]
        [StringLength(50)]
        public string Observaciones { get; set; }
        [Required(ErrorMessage = "Debe ingresar fecha")]
        [StringLength(50)]
        public string Fecha { get; set; }
        [Required]
        [StringLength(10)]
        public string Tipo_operacion { get; set; }

        public int? Id_tipodosis { get; set; }

        public virtual Tipo_Dosis Tipo_Dosis { get; set; }

        //listar dosis
        public List<Dosis> Listar()
        {
            var medicos = new List<Dosis>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    medicos = db.Dosis
                        .Include("Tipo_Dosis")
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }
        
        //Obtener dosis
        public Dosis Obtener(int id)
        {
            var medicos = new Dosis();
            try
            {
                using (var db = new ModelVacunas())
                {
                    medicos = db.Dosis
                        .Where(x => x.Id_dosis == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }
        //buscar dosis
        public List<Dosis> Buscar(string criterio)
        {
            var medicos = new List<Dosis>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    medicos = db.Dosis
                        .Where(x => x.Cantidad.Contains(criterio) || x.Fecha.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }

        //guardar dosis
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
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
        //eliminar dosis

        public void Eliminar()
        {
            try
            {
                using (var db = new ModelVacunas())
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
