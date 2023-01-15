using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> opciones):base(opciones)
        {

        }
        public DbSet<Especialidad> Especialidad {get; set;}

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
        }
    }
}