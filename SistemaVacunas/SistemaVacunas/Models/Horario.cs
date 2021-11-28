namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Horario")]
    public partial class Horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Horario()
        {
            Medico = new HashSet<Medico>();
        }

        [Key]
        public int Id_horario { get; set; }
        [Required]
        [StringLength(50)]
        public string Inicio { get; set; }
        [Required]
        [StringLength(50)]
        public string Fin { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medico> Medico { get; set; }


        public List<Horario> Listar()
        {
            var horarios = new List<Horario>();
            try
            {
                using (var db = new ModelVacunas())
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
                using (var db = new ModelVacunas())
                {
                    horarios = db.Horario
                        .Where(x => x.Id_horario == id)
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
                using (var db = new ModelVacunas())
                {
                    horarios = db.Horario
                        .Where(x => x.Inicio.Contains(criterio) || x.Fin.Contains(criterio) || x.Estado == estado)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return horarios;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_horario > 0)
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
