using CatalogModel.Models.BrandModels;
using CatalogModel.ServiceContract;
using CatalogRepository;

namespace CatalogService
{
    public class BrandService : IBrandService
    {
        private readonly BrandRepository _brandRepository;

        public BrandService(BrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public List<BrandModel> GetBrands()
        {
            List<BrandModel> brandsModels = this._brandRepository.Brands.ToList();
            return brandsModels;
        }

      

        public string GetBrandName() 
        {
            return "Brand 1";
        }

        public void CreateBrand(CreateBrandModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("CreateBrandModel cannot be null");
            }
            if (string.IsNullOrEmpty(model.Name)) 
            {
                throw new ArgumentException("Brand name cannot be null or empty");
            }

            // Created BrandModel object from CreateBrandModel
            BrandModel brandModel = new BrandModel() 
            { 
                Id = Guid.NewGuid(),
                Name = model.Name
            };

            // Add Brand to the Repository
            //this._brandRepository.Add(brandModel);
            this._brandRepository.Brands.Add(brandModel);
            this._brandRepository.SaveChanges();
        }

        public void DeleteBrand(Guid Id)
        {
            BrandModel? brandModel = this._brandRepository.Brands.Where(b => b.Id == Id).FirstOrDefault();

            if (brandModel == null) 
            {
                throw new Exception("Brand Not Found");
            }

            this._brandRepository.Brands.Remove(brandModel);
            this._brandRepository.SaveChanges();
        }

        public UpdateBrandModel GetBrandById(Guid Id)
        {
            // check if id is empty
            if(Id == Guid.Empty)
            {
                throw new ArgumentException("Id can not be empty");
            }

            // Get the Brand from the Repository
            BrandModel? model = _brandRepository.Brands.Where(b => b.Id == Id).FirstOrDefault();

            // check the brand is found
            if(model == null)
            {
                throw new Exception("Brand Not Found");
            }
            // Map Brand model to updateBrandModel
            UpdateBrandModel updateBrandModel = new UpdateBrandModel()
            {
                Id = model.Id,
                Name = model.Name
            };
            return updateBrandModel;
        }

        public void UpdateBrand(UpdateBrandModel model)
        {
            if (model == null) 
            { 
                throw new ArgumentNullException("Update Brand model is null");
            }
            BrandModel Brandmodel = new BrandModel()
            {
                Id = model.Id,
                Name = model.Name
            };
            this._brandRepository.Brands.Update(Brandmodel);
            this._brandRepository.SaveChanges();
        }
    }
}
