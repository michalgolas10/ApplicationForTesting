using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingApplicationDAL.Entities;
using static System.Formats.Asn1.AsnWriter;
using Newtonsoft.Json;

namespace TestingApplicationDAL.Context
{
    
        public class ApplicationContext : DbContext
        {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
            public DbSet<Recipe> recipes { get; set; }
            
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestingApplication;TrustServerCertificate=True;Integrated Security=true;", b => b.MigrationsAssembly("TestingApplication"));
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Recipe>()
            .Property(p => p.DietLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.HealthLabels)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.Cautions)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.IngredientLines)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.RecipeSteps)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.CuisineType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            modelBuilder.Entity<Recipe>()
            .Property(p => p.MealType)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));
            base.OnModelCreating(modelBuilder);
            }
        }
    
}
