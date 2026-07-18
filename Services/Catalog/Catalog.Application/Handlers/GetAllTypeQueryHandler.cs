using Catalog.Application.DTOs.TypeDTOs;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Application.Handlers
{
    public class GetAllTypeQueryHandler : IRequestHandler<GetAllTypeQuery, List<TypeDTO>>
    {
        private readonly TypeRepository _typeRepository;

        public GetAllTypeQueryHandler(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<List<TypeDTO>> Handle(GetAllTypeQuery request, 
            CancellationToken cancellationToken)
        {
            List<TypeModel> typeModel = await _typeRepository.Types.ToListAsync();
            return typeModel.ToTypeListMapper();
        }
    }
}
