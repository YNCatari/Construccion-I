using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaVacunas.Models
{
    public partial class ModelVacunas : DbContext
    {
        public ModelVacunas()
            : base("name=ModelVacunas")
        {
        }

        public virtual DbSet<Centro> Centro { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Dosis> Dosis { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipo_Dosis> Tipo_Dosis { get; set; }
        public virtual DbSet<Tipo_Salud> Tipo_Salud { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centro>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.Ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.Distrito)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Lugarvacunacion)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Hora)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.Cantidad)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.Tipo_operacion)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Inicio)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Fin)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Medico)
                .WithRequired(e => e.Horario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Dni)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Dni)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Dni)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Estado)
                .IsUnicode(false);
        }
    }
}
