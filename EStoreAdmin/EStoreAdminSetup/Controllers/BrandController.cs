using CatalogModel.Models.BrandModels;
using CatalogModel.ServiceContract;
using CatalogService;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminSetup.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        //private readonly IBrandService _brandService1;
        //private readonly IBrandService _brandService2;

        // constructor injection of the BrandService dependency
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
            //_brandService1 = brandService1;
            //_brandService2 = brandService2;
        }
        [Route("ListBrand")]
        public IActionResult BrandList()
        {
            List<BrandModel> brandsModels = null;
            #region
            //BrandService brandService = new BrandService();
            //brandsModels = brandService.GetBrands();
            //// unwanted method should be accessible
            //string brname = brandService.GetBrandName();


            // If we make create object and considered as reference as Interface then only contains methods should be accessible
            //IBrandService brandService = new BrandService();
            //brandsModels = brandService.GetBrands();
            //string brname = brandService.GetBrandName();
            #endregion
            
            brandsModels = _brandService.GetBrands();

            #region
            //ViewBag.BrandObject = _brandService.GetHashCode();
            //ViewBag.BrandObject1 = _brandService1.GetHashCode();
            //ViewBag.BrandObject2 = _brandService2.GetHashCode();
            #endregion

            return View(brandsModels);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateBrandModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Add Data from Model to Database 
            this._brandService.CreateBrand(model);
            return RedirectToAction("BrandList");
        }
        [HttpGet]
        [Route("Delete/{Id:Guid}")]
        public IActionResult Delete(Guid Id) 
        {
            if (Id == Guid.Empty)
            {
                throw new Exception(" Id can not be empty");
            }
            this._brandService.DeleteBrand(Id);
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        [Route("Edit/{Id:Guid}")]
        public IActionResult Edit(Guid Id) 
        {
            if (Id == Guid.Empty) 
            {
                throw new Exception("Brand id is empty");
            }
            UpdateBrandModel model = _brandService.GetBrandById(Id);
            return View(model);
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateBrand(UpdateBrandModel model) 
        {
            if (!ModelState.IsValid) 
            { 
                return View(model);
            }
            this._brandService.UpdateBrand(model);
            return RedirectToAction("BrandList");
        }
    }
}
