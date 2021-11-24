namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Citas
    {
        [Key]
        public int Id_citas { get; set; }
        [Required]
        [StringLength(50)]
        public string Lugarvacunacion { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10)]
        public string Fecha { get; set; }
        [Required]
        [StringLength(10)]
        public string Hora { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        public int? Id_paciente { get; set; }

        public int? Id_medico { get; set; }

        public int? Id_centro { get; set; }

        public int? Id_totaldosis { get; set; }

        public int? Check1 { get; set; }

        public int? Check2 { get; set; }

        public virtual Centro Centro { get; set; }

        public virtual Medico Medico { get; set; }

        public virtual Paciente Paciente { get; set; }

        public virtual Total_Dosis Total_Dosis { get; set; }


        //listar Citas
        public List<Citas> Listar()
        {
            var usuarios = new List<Citas>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    usuarios = db.Citas.Include("Centro").Include("Medico").Include("Paciente").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }
        //guardar Citas
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.Id_citas > 0)
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
        //Confirmar Citas


        //Cancelar Citas


        //Ver Citas


        //Buscar Citas
        public List<Citas> Buscar(string criterio)
        {
            var usuarios = new List<Citas>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    usuarios = db.Citas
                        .Where(x => x.Lugarvacunacion.Contains(criterio) || x.Fecha.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }




    }
}
