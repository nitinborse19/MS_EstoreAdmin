using CatalogModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CatalogRepository
{
    public class ApplicationRepository : IdentityDbContext<ApplicationUserModel>
    {
        public ApplicationRepository(DbContextOptions<ApplicationRepository> options) : base(options)
        {
            
        }
    }
}
