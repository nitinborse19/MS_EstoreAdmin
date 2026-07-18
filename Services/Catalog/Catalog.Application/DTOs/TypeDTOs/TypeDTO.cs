using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.DTOs.TypeDTOs
{
    public record TypeDTO
    (
        Guid Id,
        string Name
    );
}
