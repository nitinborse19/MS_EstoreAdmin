using Catalog.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public record GetProductByBrandIdQuery(Guid BrandId) : IRequest<List<ProductDTO>>
    {
    }
}
