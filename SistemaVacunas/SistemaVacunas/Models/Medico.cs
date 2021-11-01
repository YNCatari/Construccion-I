namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Medico")]
    public partial class Medico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medico()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int Id_medico { get; set; }
        [Required]
        [StringLength(8)]
        public string Dni { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(70)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(9)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(10)]
        public string Sexo { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(8)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        public int? Id_rol { get; set; }

        public int Id_horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Rol Rol { get; set; }


        //listar medico
        public List<Medico> Listar()
        {
            var medicos = new List<Medico>();
            try
            {
                using (var db = new ModelVacuna())
                {
               
                    medicos = db.Medico
                        .Include("Rol")
                        .Include("Horario")
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }
        //guardar medico
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.Id_medico > 0)
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
        //Obtener medico
        public Medico Obtener(int id)
        {
            var medicos = new Medico();
            try
            {
                using (var db = new ModelVacuna())
                {
                    medicos = db.Medico
                        .Where(x => x.Id_medico == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }
        //Buscar medico
        public List<Medico> Buscar(string criterio)
        {
            var medicos = new List<Medico>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    medicos = db.Medico
                        .Where(x => x.Nombre.Contains(criterio) || x.Dni.Contains(criterio))
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }

    }
}
