using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones):base(opciones)
        {

        }
        public DbSet<Especialidad> Especialidad {get; set;}
        public DbSet<Paciente> Paciente {get;set;}
        public DbSet<Medico> Medico { get; set; }

        public DbSet<MedicoEspecialidad> MedicoEspecialidad{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)  // metodo protegido, no puede ser accedido ni modificado desde otro componente. Override va sobreescribir el metodo OnModelCreating con lo que hay en el nuevo metodo
        {
            modelBuilder.Entity<Especialidad>(entidad =>                    //en la creacion de la tabla especificamos las propiedades que necesitamos en los campos
            {
                entidad.ToTable("Especialidad");                            //nombre de la tabla
                entidad.HasKey(e => e.IdEspecialidad);                      //llave principal de la tabla
                entidad.Property(e => e.Descripcion)                        //campo de tabla      
                .IsRequired()                                               //campo es requerido (no perminte nan)
                .HasMaxLength(200)                                          //su tamaño maximo
                .IsUnicode(false);
            });
            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(p => p.IdPaciente);
                entidad.Property(p=> p.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p=> p.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(p=> p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p=> p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p=> p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Medico>(entidad =>
                {
                    entidad.ToTable("Medico");

                    entidad.HasKey(m => m.IdMedico);

                    entidad.Property(m => m.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    entidad.Property(m => m.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    entidad.Property(m => m.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                    entidad.Property(m => m.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                    entidad.Property(m => m.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                    entidad.Property(m => m.HorarioAtencionDesde)
                    .IsRequired()
                    .IsUnicode(false);

                    entidad.Property(m => m.HorarioAtencionHasta)
                    .IsRequired()
                    .IsUnicode(false);
                }
            );
            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x=> new{x.IdMedico, x.IdEspecialidad});

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x=> x.Medico)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x=> x.Especialidad)
            .WithMany(p => p.MedicoEspecialidad)
            .HasForeignKey(p => p.IdEspecialidad);
        }

        
    }
}