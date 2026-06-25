using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.Models.TypeModels
{
    public class CreateTypeModel
    {
        [Required(ErrorMessage = "Type Name is Required"),MaxLength(255)]

        public string Name { get; set; } = string.Empty;
    }
}
