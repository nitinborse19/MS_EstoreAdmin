using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public class CreateTypeCommand: IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
