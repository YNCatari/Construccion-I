namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Pacientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacientes()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_pacientes { get; set; }

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
        [StringLength(255)]
        public string direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public List<Pacientes> Listar()
        {
            var pacientes = new List<Pacientes>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    pacientes = db.Pacientes.ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return pacientes;
        }
        public Pacientes Obtener(int id)
        {
            var pacientes = new Pacientes();
            try
            {
                using (var db = new ModelVacuna())
                {
                    pacientes = db.Pacientes
                        .Where(x => x.id_pacientes == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return pacientes;
        }
        public List<Pacientes> Buscar(string criterio)
        {
            var pacientes = new List<Pacientes>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacuna())
                {
                    pacientes = db.Pacientes
                        .Where(x => x.dni.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return pacientes;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_pacientes > 0)
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
            catch (Exception )
            {
                throw;
            }
        }
    }
}

