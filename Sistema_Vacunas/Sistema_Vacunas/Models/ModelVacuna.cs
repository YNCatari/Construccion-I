using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sistema_Vacunas.Models
{
    public partial class ModelVacuna : DbContext
    {
        public ModelVacuna()
            : base("name=ModelVacuna")
        {
        }

        public virtual DbSet<Centro> Centro { get; set; }
        public virtual DbSet<Check1> Check1 { get; set; }
        public virtual DbSet<Check2> Check2 { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Dosis> Dosis { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipo_Dosis> Tipo_Dosis { get; set; }
        public virtual DbSet<Tipo_Salud> Tipo_Salud { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centro>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.calle)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.distrito)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .Property(e => e.codigopostal)
                .IsUnicode(false);

            modelBuilder.Entity<Centro>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Centro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Check1>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Check1>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Check1>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Check1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Check2>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Check2>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Check2>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Check2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.lugarvacunacion)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.horario_atencion)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.cantidad)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Dosis>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Dosis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.iniciohorario)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.iniciofin)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Medicos)
                .WithRequired(e => e.Horario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.turno_mañana)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Medicos>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Medicos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Pacientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Medicos)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Dosis>()
                .HasMany(e => e.Dosis)
                .WithRequired(e => e.Tipo_Dosis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Salud>()
                .HasMany(e => e.Centro)
                .WithRequired(e => e.Tipo_Salud)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.estado)
                .IsUnicode(false);
        }
    }
}
