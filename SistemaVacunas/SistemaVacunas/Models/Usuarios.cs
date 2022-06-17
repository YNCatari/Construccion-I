/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Usuarios - 2*/
namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /*TODO: Llamando Las Librerias */
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    //*TODO: Modelo Usuario  y Atributos */
    public partial class Usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar nombre")]
        [StringLength(10)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar apellidos")]
        [StringLength(20)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Debe ingresar un dni")]
        [StringLength(8)]
        public string Dni { get; set; }
        [Required(ErrorMessage = "Debe ingresar  direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Debe ingresar telefono")]
        [StringLength(9)]
        public string Telefono { get; set; }
        [Display(Name = "Correo Electr�nico")]
        [Required(ErrorMessage = "Este Campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Direcci�n de Correo electr�nico incorrecta.")]
        [StringLength(50, ErrorMessage = "Longitud m�xima 100")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Contrase�a")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(8, ErrorMessage = "Longitud entre 1 y 6 caracteres.",
                      MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
        public int? Id_rol { get; set; }
        public virtual Rol Rol { get; set; }
        ModelVacunas db = new ModelVacunas();

        //*TODO: Funcion para Autentificar de acceso del usuario */
        public bool Autenticar()
        {

            return db.Usuarios
                   .Where(x => x.Email == this.Email
                   && x.Password == this.Password)
                   .FirstOrDefault() != null;


        }

        //Obtener email de confirmacion
        public Usuarios ObtenerDatos(string email)
        {
            var usuario = new Usuarios();
            try
            {
                using (var db = new ModelVacunas())
                {
                    usuario = db.Usuarios.Include("Rol")
                        .Where(x => x.Email == email)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
        
        //Listar Usuarios
        public List<Usuarios> Listar()
        {
            var usuarios = new List<Usuarios>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    usuarios = db.Usuarios.Include("Rol").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }
        
        //Registrar Usuarios
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacunas())
                {
                    if (this.Id_usuario > 0)
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


        //Obtener Usuarios
        public Usuarios Obtener(int id)
        {
            var usuarios = new Usuarios();
            try
            {
                using (var db = new ModelVacunas())
                {
                    usuarios = db.Usuarios
                        .Where(x => x.Id_usuario == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }


        //Buscar Usuarios
        public List<Usuarios> Buscar(string criterio)
        {
            var usuarios = new List<Usuarios>();
            try
            {
                using (var db = new ModelVacunas())
                {
                    usuarios = db.Usuarios
                        .Where(x => x.Nombre.Contains(criterio) || x.Dni.Contains(criterio))
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
