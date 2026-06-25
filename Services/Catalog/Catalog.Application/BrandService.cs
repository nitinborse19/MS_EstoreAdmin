using Catalog.Core;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application
{
    public class BrandService : IBrandService
    {
        private readonly BrandRepository _brandRepository;

        public BrandService(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> DeleteBrandById(Guid Id)
        {
            if(Id == Guid.Empty)
                throw new ArgumentException("Id is required", nameof(Id));

            var brand = await this._brandRepository.brands.FirstOrDefaultAsync(x => x.Id == Id);
            return true;
        }

        public async Task<BrandModel> GetBrandById(Guid Id)
        {
            BrandModel? model = null;
            model = this._brandRepository.brands.Where(x => x.Id == Id).FirstOrDefault();
            if (model == null) 
            { 
                throw new Exception($"Brand with Id {Id} not found");
            }
            return model;
        }

        public async Task<List<BrandModel>> GetBrands()
        {
            List<BrandModel> brandModels = null;

            brandModels = await this._brandRepository.brands.ToListAsync();
             
            return brandModels;
        }
    }
}
