using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Data.Configurations;
using UdemyNLayerProject.Data.Seed;

namespace UdemyNLayerProject.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).UseIdentityColumn();
            
            modelBuilder.Entity<Person>().Property(P => P.Surname).HasMaxLength(40);
            modelBuilder.Entity<Person>().Property(p => p.Name).HasMaxLength(40);
            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1,2 }));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
