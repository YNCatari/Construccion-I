namespace Sistema_Vacunas.Models
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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(255)]
        public string direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string contraseña { get; set; }

        [Required]
        [StringLength(10)]
        public string estado { get; set; }

        public int id_rol { get; set; }

        public virtual Rol Rol { get; set; }

        ModelVacuna db = new ModelVacuna();

        //login
        public bool Autenticar()
        {

            return db.Usuarios
                   .Where(x => x.email == this.email
                   && x.contraseña == this.contraseña)
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
                        .Where(x => x.email == email)
                        .SingleOrDefault();
                }
            }
            catch (Exception )
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
        public void Guardar()
        {
            try
            {
                using (var db = new ModelVacuna())
                {
                    if (this.id_usuario > 0)
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
                        .Where(x => x.id_usuario == id)
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
                        .Where(x => x.nombre.Contains(criterio) || x.dni.Contains(criterio))
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
