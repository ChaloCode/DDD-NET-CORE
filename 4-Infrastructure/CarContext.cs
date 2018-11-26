namespace Infrastructure
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Domain.Entities.car;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Cotietiene la conexion a la base de datos
    /// </summary>
    public class CarContext : DbContext 
    {
        public CarContext (DbContextOptions<CarContext> options) : base (options) { }

        public CarContext() { }

        /// <summary>
        /// Obiete la cadena de conexión del archivo appsettings.json del proyecto de arranque de la capa de presentación
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("CarConnection"));
            }

        }

        /// <summary>
        /// Crea modelo al cual se le puede hacer operaciones de Query o Persistencia
        /// esta relacionado con una tabla en la base de datos
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Esta encargado de mapear los atributos de la indentidad 
        /// con los nombre de columna de la base de datos.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Carro");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Id)
                        .HasColumnName("Id");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Model)
                        .HasColumnName("Modelo");
            modelBuilder.Entity<Car>()
                        .Property(c => c.Name)
                        .HasColumnName("Nombre");         
            modelBuilder.Entity<Car>().HasKey(vf => new { vf.Id });
        }
    }
}