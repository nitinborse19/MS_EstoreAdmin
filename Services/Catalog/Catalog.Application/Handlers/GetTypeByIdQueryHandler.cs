using Catalog.Application.DTOs.TypeDTOs;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQuery, TypeDTO>
    {
        private readonly TypeRepository _typeRepository;

        public GetTypeByIdQueryHandler(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<TypeDTO> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            TypeModel? typeModel = await this._typeRepository.Types.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
            return typeModel.ToTypeMapper();
        }
    }
}

