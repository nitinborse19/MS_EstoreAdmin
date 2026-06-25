using System.ComponentModel.DataAnnotations;

namespace CatalogModel.Models.BrandModels
{
    public class CreateBrandModel
    {
        [Required(ErrorMessage = "Brand Name is Required")]

        public string Name { get; set; } = string.Empty;
    }
}
