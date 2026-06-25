using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.Models.TypeModels
{
    public class TypeModel
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Type Name is Required")]
        public string Name { get; set; } = string.Empty;
    }
}
