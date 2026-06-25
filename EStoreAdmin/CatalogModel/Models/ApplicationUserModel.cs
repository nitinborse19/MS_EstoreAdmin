
using Microsoft.AspNetCore.Identity;

namespace CatalogModel.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
