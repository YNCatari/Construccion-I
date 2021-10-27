namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;


    public partial class Medicos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medicos()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_medico { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string apellidos { get; set; }

        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string sexo { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string turno_mañana { get; set; }

        [Required]
        [StringLength(255)]
        public string contraseña { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int id_rol { get; set; }

        public int id_horario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public virtual Horario Horario { get; set; }

        public virtual Rol Rol { get; set; }

        //ModelVacuna db = new ModelVacuna();

        //listar usuarios
        public List<Medicos> Listar()
        {
            var medicos = new List<Medicos>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    //usuarios = db.Usuarios.Include("Rol").ToList();
                    medicos = db.Medicos
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
        //guardar usuarios
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_medico > 0)
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
        //Obtener usuarios
        public Medicos Obtener(int id)
        {
            var medicos = new Medicos();
            try
            {
                using (var db = new ModelVacuna())
                {
                    medicos = db.Medicos
                        .Where(x => x.id_medico == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return medicos;
        }
        //Buscar usuarios
        public List<Medicos> Buscar(string criterio)
        {
            var medicos = new List<Medicos>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    medicos = db.Medicos
                        .Where(x => x.nombre.Contains(criterio) || x.dni.Contains(criterio))
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
