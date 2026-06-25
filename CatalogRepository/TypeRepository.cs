using CatalogModel.Models.TypeModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository
{
    public class TypeRepository : DbContext
    {
        public TypeRepository( DbContextOptions<TypeRepository> options) : base(options)
        {
            
        }
        // For Querying Data from Type Table
        public DbSet<TypeModel> TypesModels { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TypeModel>().ToTable("Types");

            modelBuilder.Entity<TypeModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
            }
            );

            modelBuilder.Entity<TypeModel>().HasData(
                new TypeModel()
                {
                    Id = Guid.NewGuid(),
                    Name ="Television"
                }
                );
            modelBuilder.Entity<TypeModel>().HasData(
                new TypeModel()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mobile"
                }
                );
            modelBuilder.Entity<TypeModel>().HasData(
                new TypeModel()
                { 
                    Id = Guid.NewGuid(),
                    Name = "Fridge"
                }
                );
        }

    }
}
