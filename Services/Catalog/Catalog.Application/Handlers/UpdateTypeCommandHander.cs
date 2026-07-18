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
    public class UpdateTypeCommandHander : IRequestHandler<UpdateTypeCommand, bool>
    {
        private readonly TypeRepository _typeRepository;

        public UpdateTypeCommandHander(TypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<bool> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            TypeModel typeModel = new TypeModel()
            {
                Id = request.id,
                Name = request.name
            };
            this._typeRepository.Types.Update(typeModel);
            await this._typeRepository.SaveChangesAsync();
            return true;
        }
    }
}
