using CatalogModel.Models.BrandModels;
using CatalogModel.Models.TypeModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.Models.ProductModel
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public Guid BrandId { get; set; }=Guid.Empty;
        public Guid TypeId { get; set; } = Guid.Empty;

        public string ImageFilePath { get; set; } = string.Empty;
        public int ProductCost { get; set; }
        public int GST { get; set; }

        public int ProductTotalCost { get; set; }

    }
}
