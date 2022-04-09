namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Paciente")]
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            Citas = new HashSet<Citas>();
        }

        [Key]
        public int Id_paciente { get; set; }
        [Required(ErrorMessage = "Debe ingresar un dni")]
        [StringLength(8)]
        public string Dni { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombres")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar apellidos")]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Debe ingresar direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar telefono / movil")]
        [StringLength(9)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(50, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Citas> Citas { get; set; }

        public List<Paciente> Listar()
        {
            var pacientes = new List<Paciente>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    pacientes = db.Paciente.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pacientes;
        }
        public Paciente Obtener(int id)
        {
            var pacientes = new Paciente();
            try
            {
                using (var db = new ModelVacunas())
                {
                    pacientes = db.Paciente
                        .Where(x => x.Id_paciente == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pacientes;
        }
        public List<Paciente> Buscar(string criterio)
        {
            var pacientes = new List<Paciente>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModelVacunas())
                {
                    pacientes = db.Paciente
                        .Where(x => x.Dni.Contains(criterio) || x.Estado == estado)
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return pacientes;
        }
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_paciente > 0)
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
