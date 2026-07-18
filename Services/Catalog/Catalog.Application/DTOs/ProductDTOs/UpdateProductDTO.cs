using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs.ProductDTOs
{
    public record UpdateProductDTO
    (
        string ProductName,
        string ProductDescription,
        Guid BrandId,
        Guid TypeId,
        string ImageFilePath,
        int ProductCost,
        int GST
        );
}
