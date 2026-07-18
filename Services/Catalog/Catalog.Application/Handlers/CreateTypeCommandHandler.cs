using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, Guid>
    {
        private readonly TypeRepository _typeRepository;

        public CreateTypeCommandHandler(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<Guid> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            TypeModel typeModel = new TypeModel()
            {
                Id = new Guid(),
                Name= request.Name
            };
            await this._typeRepository.Types.AddAsync(typeModel);
            await this._typeRepository.SaveChangesAsync();
            return typeModel.Id;
        }
    }
}
