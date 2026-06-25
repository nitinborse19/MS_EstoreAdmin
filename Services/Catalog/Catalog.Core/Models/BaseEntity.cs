using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}
