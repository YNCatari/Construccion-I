namespace Sistema_Vacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            Medicos = new HashSet<Medicos>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_horario { get; set; }

        [Required]
        [StringLength(20)]
        public string iniciohorario { get; set; }

        [Required]
        [StringLength(20)]
        public string iniciofin { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medicos> Medicos { get; set; }


        public List<Horario> Listar()
        {
            var horarios = new List<Horario>();
            try
            {
                using (var db = new ModelVacuna())
                {
                    horarios = db.Horario.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return horarios;
        }
        public Horario Obtener(int id)
        {
            var horarios = new Horario();
            try
            {
                using (var db = new ModelVacuna())
                {
                    horarios = db.Horario
                        .Where(x => x.id_horario == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return horarios;
        }
        public List<Horario> Buscar(string criterio)
        {
            var horarios = new List<Horario>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacuna())
                {
                    horarios = db.Horario
                        .Where(x => x.iniciohorario.Contains(criterio) || x.iniciofin.Contains(criterio) || x.estado == estado)
                        .ToList();
                }
            }
            catch (Exception )
            {
                throw;
            }
            return horarios;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_horario > 0)
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
