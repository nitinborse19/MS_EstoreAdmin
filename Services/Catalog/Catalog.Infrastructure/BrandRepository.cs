using Catalog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure
{
    public class BrandRepository : DbContext
    {
        public BrandRepository(DbContextOptions<BrandRepository> options) : base(options)
        {
            
        }
        public DbSet<BrandModel> brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
