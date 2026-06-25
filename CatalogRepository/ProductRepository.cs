using CatalogModel.Models.ProductModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository
{
    public class ProductRepository : DbContext
    {
        public ProductRepository(DbContextOptions<ProductRepository> options) : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region
            //modelBuilder.Entity<ProductModel>().ToTable("Products");

            //modelBuilder.Entity<ProductModel>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.ProductName).IsRequired();
            //    entity.Property(e => e.ProductDescription).IsRequired();
            //    entity.Property(e => e.BrandId).IsRequired();
            //    entity.Property(e => e.TypeId).IsRequired();
            //    entity.Property(e => e.ImageFilePath).IsRequired();
            //    entity.Property(e => e.ProductCost).IsRequired();
            //    entity.Property(e => e.GST).IsRequired();
            //    entity.Property(e => e.ProductTotalCost).IsRequired();
            //});

            //modelBuilder.Entity<ProductModel>().HasData(
            //    new ProductModel
            //    {
            //        Id = Guid.NewGuid(),
            //        ProductName = "Product 1",
            //        ProductDescription = "Description for Product 1",
            //        BrandId = Guid.NewGuid(),
            //        TypeId = Guid.NewGuid(),
            //        ImageFilePath = "path/to/image1.jpg",
            //        ProductCost = 100,
            //        GST = 18,
            //        ProductTotalCost = 118
            //    }
            //    );
            #endregion
        }
    }
}
