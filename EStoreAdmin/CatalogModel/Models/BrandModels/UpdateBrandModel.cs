using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.Models.BrandModels
{
    public class UpdateBrandModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Brand Name is Required")]
        public string Name { get; set; } = string.Empty;
    }
}
