using Catalog.Application.DTOs.TypeDTOs;
using Catalog.Core.Models;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllTypeQuery : IRequest<List<TypeDTO>>
    {
    }
}
