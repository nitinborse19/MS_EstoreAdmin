using Catalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core
{
    public interface IBrandService
    {
        Task<List<BrandModel>> GetBrands();

        Task<BrandModel> GetBrandById(Guid Id);

        Task<bool> DeleteBrandById(Guid Id);


    }
}
