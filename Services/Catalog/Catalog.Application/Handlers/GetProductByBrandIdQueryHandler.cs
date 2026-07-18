using Catalog.Application.DTOs.ProductDTOs;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandIdQueryHandler : IRequestHandler<GetProductByBrandIdQuery, List<ProductDTO>>
    {
        private readonly ProductRepository _productRepository;

        public GetProductByBrandIdQueryHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> Handle(GetProductByBrandIdQuery request, CancellationToken cancellationToken)
        {
             
            List<ProductModel> products = await this._productRepository.products.Where(p => p.BrandId == request.BrandId).ToListAsync();

            return products.ToProductListMapper();
        }
    }
}
