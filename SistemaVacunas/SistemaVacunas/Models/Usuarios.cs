/*Autores: YNCatari /PYVargas */
/*Fecha de Creacion: 27/08/2021-II*/
/*CU: Usuarios*/
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
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(50)]
        public string Dni { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(9)]
        public string Telefono { get; set; }
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
        //*TODO: Funcion para Obtener Datos  de acceso del usuario */
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
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }
        /*TODO: Listar todos los Usuarios  Registrados*/

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
        /*TODO: Funcion para Registar y Actualizar Usuario */

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


        /*TODO: Mostrar los datos del usuario segun el ID */
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


        /*TODO: Buscar los datos del usuario segun el Dni */
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
