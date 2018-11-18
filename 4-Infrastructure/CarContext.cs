namespace Infrastructure
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Domain.Entities.car;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class CarContext : DbContext 
    {
        public CarContext (DbContextOptions<CarContext> options) : base (options) { }
        
        public DbSet<Car> Cars { get; set; }
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