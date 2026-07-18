using Catalog.Application.Commands;
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
    public class DeleteTypeByIdCommandHandler : IRequestHandler<DeleteTypeByIdCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public DeleteTypeByIdCommandHandler(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<bool> Handle(DeleteTypeByIdCommand request, CancellationToken cancellationToken)
        {
            TypeModel? typeModel = null;
            typeModel = await this._typeRepository.Types.Where(t => t.Id == request.id).FirstOrDefaultAsync();
            if (typeModel == null) 
            {
                throw new Exception("Excepted type is not available"); 
            }
            this._typeRepository.Types.Remove(typeModel);
            await this._typeRepository.SaveChangesAsync();
            return true;
        }
    }
}
