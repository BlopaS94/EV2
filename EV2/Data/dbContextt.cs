using Microsoft.EntityFrameworkCore;
using EV2.Models;

namespace EV2.Data
{
    public class dbContextt : DbContext
    {
        public dbContextt(DbContextOptions<dbContextt> options) : base(options)
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Herramienta> Herramientas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales para Roles
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Nombre = "Administrador"
            });

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 2,
                Nombre = "Empleado"
            });

            // Datos iniciales para Usuarios
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Nombre = "Alejandro ",
                Email = "jano@jano.cl",
                Password = "12345",
                RolId = 1
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 2,
                Nombre = "Alegriaa",
                Email = "janito@janito.cl",
                Password = "12345",
                RolId = 2
            });
        }
    }
}
