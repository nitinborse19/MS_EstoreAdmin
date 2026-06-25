using CatalogModel.Models.BrandModels;
using CatalogModel.ServiceContract;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace CatalogRepository
{
    public class BrandRepository : DbContext   /// DbContext is abstract class
    {
        public BrandRepository(DbContextOptions<BrandRepository> options):base(options)
        {
            
        }

        public DbSet<BrandModel> Brands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region
            //// Map the BrandModel  to the "Brands" table in the database
            //modelBuilder.Entity<BrandModel>().ToTable("Brands");

            //// Configure the properties of the BrandModel
            //modelBuilder.Entity<BrandModel>(entity =>
            //{
            //    entity.HasKey(e => e.Id); // set id as the primary key
            //    entity.Property(e => e.Name).IsRequired(); // Make name required
            //});

            //// Seed initial data for the BrandModel
            //modelBuilder.Entity<BrandModel>().HasData(
            //    new BrandModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Brand 1"
            //    },
            //     new BrandModel
            //     {
            //         Id = Guid.NewGuid(),
            //         Name = "Brand 2"
            //     },
            //      new BrandModel
            //      {
            //          Id = Guid.NewGuid(),
            //          Name = "Brand 3"
            //      }
            //    );
            #endregion
        }
    }
}
