using Catalog.Application.Commands;
using Catalog.Application.DTOs.ProductDTOs;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var query = new GetAllProductQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO requestDTO)
        {
            var command = new CreateProductCommand();
            command.ProductName = requestDTO.ProductName;
            command.ProductDescription = requestDTO.ProductDescription;
            command.BrandId = requestDTO.BrandId;
            command.TypeId = requestDTO.TypeId;
            command.ImageFilePath = requestDTO.ImageFilePath;
            command.ProductCost = requestDTO.ProductCost;
            command.GST = requestDTO.GST;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            var command = new DeleteProductByIdCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO requestDTO)
        {
            var command = new UpdateProductCommand();
            command.ProductName = requestDTO.ProductName;
            command.ProductDescription = requestDTO.ProductDescription;
            command.BrandId = requestDTO.BrandId;
            command.TypeId = requestDTO.TypeId;
            command.ImageFilePath = requestDTO.ImageFilePath;
            command.ProductCost = requestDTO.ProductCost;
            command.GST = requestDTO.GST;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductByBrand")]
        public async Task<IActionResult> GetProductByBrand(Guid Id)
        {
            var query = new GetProductByBrandIdQuery(Id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}
