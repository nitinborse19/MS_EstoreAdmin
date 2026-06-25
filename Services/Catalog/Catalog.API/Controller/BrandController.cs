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
        [Route("ListProduct")]
        public async Task<IActionResult> ListProduct()
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
    }
}
