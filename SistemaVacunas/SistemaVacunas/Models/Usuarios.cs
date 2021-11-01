namespace SistemaVacunas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
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

        public int Id_rol { get; set; }

        public virtual Rol Rol { get; set; }


        ModelVacuna db = new ModelVacuna();

        //login
        public bool Autenticar()
        {

            return db.Usuarios
                   .Where(x => x.Email == this.Email
                   && x.Password == this.Password)
                   .FirstOrDefault() != null;


        }
        //obtener datos del login
        public Usuarios ObtenerDatos(string email)
        {
            var usuario = new Usuarios();
            try
            {
                using (var db = new ModelVacuna())
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
        //listar usuarios
        public List<Usuarios> Listar()
        {
            var usuarios = new List<Usuarios>();
            try
            {
                using (var db = new ModelVacuna())
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
        //guardar usuarios
        public void Registrar()
        {
            try
            {
                using (var db = new ModelVacuna())
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
        //Obtener usuarios
        public Usuarios Obtener(int id)
        {
            var usuarios = new Usuarios();
            try
            {
                using (var db = new ModelVacuna())
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
        //Buscar usuarios
        public List<Usuarios> Buscar(string criterio)
        {
            var usuarios = new List<Usuarios>();
            try
            {
                using (var db = new ModelVacuna())
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
