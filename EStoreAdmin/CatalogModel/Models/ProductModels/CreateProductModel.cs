using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CatalogModel.Models.ProductModels
{
    public class CreateProductModel
    {
        [Required(ErrorMessage ="Product Name is Required"),MaxLength(200)]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product Description is Required")]
        public string ProductDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "select brand name is Required")]
        public Guid BrandId { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "select type name is Required")]
        public Guid TypeId { get; set; } = Guid.Empty;

        [Required(ErrorMessage =" Upload Image")]
        public IFormFile ImageFilePath { get; set; } = null;

        [Required(ErrorMessage = "Product Cost is Required")]
        public int ProductCost { get; set; }
    }
}
