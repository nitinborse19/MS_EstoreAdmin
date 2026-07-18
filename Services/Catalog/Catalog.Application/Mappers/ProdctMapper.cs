using Catalog.Application.DTOs.ProductDTOs;
using Catalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public static class ProdctMapper
    {
        public static List<ProductDTO> ToProductListMapper(this List<ProductModel> products)
        {
            List<ProductDTO> productDTOs = null;
            if (products != null) 
            {
                productDTOs = new List<ProductDTO>();
                foreach (var product in products) 
                {
                    productDTOs.Add(ToProductMapper(product));
                }
            }
            return productDTOs;
        }

        public static ProductDTO ToProductMapper(this ProductModel products) 
        {
            ProductDTO productDTO = null;
            if (products != null) 
            {
                productDTO = new ProductDTO(
                    products.Id,
                    products.ProductName,
                    products.ProductDescription,
                    products.BrandId,
                    products.TypeId,
                    products.ImageFilePath,
                    products.ProductCost,
                    products.GST,
                    products.ProductTotalCost
                    );

            }
            return productDTO;
        }

    }
}
