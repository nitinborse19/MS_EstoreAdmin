using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Models
{
    public class UpdateBrandModel: BaseEntity
    {
        public string BrandName { get; set; } = string.Empty;
    }
}
