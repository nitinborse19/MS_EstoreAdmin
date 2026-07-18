using Catalog.Application;
using Catalog.Core;
using Catalog.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Route("ListBrands")]
        public async Task<IActionResult> ListBrands()
        {
            List<BrandModel>  brands = await this._brandService.GetBrands();   
            return Ok(brands);
        }

        [HttpGet]
        [Route("GetBrandById")]
        public async Task<IActionResult> GetBrandById(Guid Id)
        {
            if(Id == Guid.Empty)
                return BadRequest("Id is required");

            BrandModel brand = await this._brandService.GetBrandById(Id);
            return Ok(brand);
        }

        [HttpDelete]
        [Route("DeleteBrandById")]

        public async Task<IActionResult> DeleteBrandById(Guid Id)
        {
            if(Id == Guid.Empty)
                return BadRequest("Id is required");

            BrandModel brand = await this._brandService.GetBrandById(Id);
            if(brand == null)
                return NotFound($"Brand with Id {Id} not found");

            // Here you would call a method to delete the brand, e.g.:
            await this._brandService.DeleteBrandById(Id);

            return Ok($"Brand with Id {Id} deleted successfully");
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandModel model)
        {
            if(model == null)
            {
                throw new Exception("Create Brand model is null or empty");
            }
            if(model.BrandName == null || model.BrandName.Trim() == string.Empty)
            {
                throw new Exception("Brand Name is required");
            }
            await this._brandService.CreateBrand(model);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandModel updateBrandModel)
        {
            if(updateBrandModel == null)
            {
                throw new Exception("Update Brand model is null or empty");
            }
            if(updateBrandModel.Id == Guid.Empty)
            {
                throw new Exception("Brand Id is required");
            }
            if(updateBrandModel.BrandName == null || updateBrandModel.BrandName.Trim() == string.Empty)
            {

               throw new Exception("Brand Name is required");
            }
            await this._brandService.UpdateBrand(updateBrandModel);
            return Ok();
        }
    }
}
