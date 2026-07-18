using Catalog.Application.DTOs.TypeDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public record GetTypeByIdQuery(Guid Id) : IRequest<TypeDTO>
    {
    }
}
