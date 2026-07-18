using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Models
{
    public class ProductModel: BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = String.Empty;
        public Guid BrandId { get; set; }
        public Guid TypeId {  get; set; }
        public string ImageFilePath { get; set; } = string.Empty;
        public int ProductCost { get; set; }
        public int GST { get; set; }
        public int ProductTotalCost { get; set; }
    }
}
