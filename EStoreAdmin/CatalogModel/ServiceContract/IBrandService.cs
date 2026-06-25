using CatalogModel.Models.BrandModels;

namespace CatalogModel.ServiceContract
{
    public interface IBrandService
    {
        List<BrandModel> GetBrands();
        void CreateBrand(CreateBrandModel model);

        void DeleteBrand(Guid Id);

        UpdateBrandModel GetBrandById(Guid Id);

        void UpdateBrand(UpdateBrandModel model);
    }
}
