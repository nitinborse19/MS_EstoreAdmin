using CatalogModel.Models.ProductModel;
using CatalogModel.Models.ProductModels;
using CatalogModel.ServiceContract;
using CatalogService;
using Microsoft.AspNetCore.Mvc;

namespace EStoreAdminSetup.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ITypeService _typeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService productService,IBrandService brandService,ITypeService typeService
            ,IWebHostEnvironment webHostEnvironment)
        {
            this._productService = productService;
            this._brandService = brandService;
            this._typeService = typeService;
            this._webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            List<ProductModel>? productModel = null;
            productModel = this._productService.GetProducts();
            return View(productModel);
        }

        [HttpGet]
        [Route("DeleteProduct{Id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("Product Id is not Empty");
            }
            this._productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("CreateProduct")]
        public IActionResult CreateProduct()
        {
            // call BrandList
            var BrandList = this._brandService.GetBrands();
            ViewBag.Brands = BrandList;
            // call TypeList
            var TypeList = this._typeService.ListGetType();
            ViewBag.Types = TypeList;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct(CreateProductModel createProductModel)
        {
            if (!ModelState.IsValid)
            {
                // call BrandList
                var BrandList = this._brandService.GetBrands();
                ViewBag.Brands = BrandList;
                // call TypeList
                var TypeList = this._typeService.ListGetType();
                ViewBag.Types = TypeList;
                return View(createProductModel);
            }
            string imagefile = _webHostEnvironment.ContentRootPath;
            imagefile += "\\wwwroot\\Products\\";
            string  filename = Guid.NewGuid().ToString();
            imagefile += filename;
            imagefile += Path.GetExtension(createProductModel.ImageFilePath.FileName);
            using(var filestream = new FileStream(imagefile, FileMode.Create))
            {
                createProductModel.ImageFilePath.CopyTo(filestream);
            }
            string FilePath = filename + Path.GetExtension(createProductModel.ImageFilePath.FileName);
            // call CreateProduct method of ProductService
            this._productService.CreateProduct(createProductModel, FilePath);
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("EditProduct{Id:guid}")]
        public IActionResult EditProduct(Guid Id)
        {
            if (Id == Guid.Empty) 
            {
                throw new Exception("Product Id is Empty");
            }
            // call BrandList
            var BrandList = this._brandService.GetBrands();
            ViewBag.Brands = BrandList;
            // call TypeList
            var TypeList = this._typeService.ListGetType();
            ViewBag.Types = TypeList;
            
            UpdateProductModel updateProductModel = this._productService.GetProductById(Id);
            if(updateProductModel == null)
            {
                throw new Exception("Product not found");
            }

            return View(updateProductModel);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductModel updateProductModel)
        {
            if (!ModelState.IsValid)
            {
                // call BrandList
                var BrandList = this._brandService.GetBrands();
                ViewBag.Brands = BrandList;
                // call TypeList
                var TypeList = this._typeService.ListGetType();
                ViewBag.Types = TypeList;
                return View(updateProductModel);
            }
            string ImageUrl = _productService.GetProductUrl(updateProductModel.Id);
            string imagefile = _webHostEnvironment.ContentRootPath;
            imagefile += "\\wwwroot\\Products\\";

            if(updateProductModel.ImageFilePath != null)
            {
                string DeleteFileName = imagefile + ImageUrl;

                if (System.IO.File.Exists(DeleteFileName))
                {
                    System.IO.File.Delete(DeleteFileName);
                }
            }

            string filename = Guid.NewGuid().ToString();
            imagefile += filename;
            imagefile += Path.GetExtension(updateProductModel.ImageFilePath.FileName);
            using (var filestream = new FileStream(imagefile, FileMode.Create))
            {
                updateProductModel.ImageFilePath.CopyTo(filestream);
            }
            string FilePath = filename + Path.GetExtension(updateProductModel.ImageFilePath.FileName);

            // call UpdateProduct method of ProductService
            this._productService.UpdateProduct(updateProductModel,FilePath);
            return RedirectToAction("Index");
        }
    }
}
