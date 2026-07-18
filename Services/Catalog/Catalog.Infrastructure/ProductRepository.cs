using Catalog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public class ProductRepository : DbContext
    {
        public ProductRepository(DbContextOptions<ProductRepository> options) : base(options)
        {
            
        }

        public DbSet<ProductModel> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
