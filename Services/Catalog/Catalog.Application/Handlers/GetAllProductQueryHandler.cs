using Catalog.Application.DTOs.ProductDTOs;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductDTO>>
    {
        private readonly ProductRepository _productRepository;

        public GetAllProductQueryHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<ProductModel> productModel = await this._productRepository.products.ToListAsync();

            return productModel.ToProductListMapper();
        }
    }
}
