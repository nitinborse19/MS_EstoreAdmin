using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public record UpdateTypeCommand:IRequest<bool>
    {
        public Guid id { get; set; } = Guid.Empty;
        public string name { get; set; } = string.Empty;
    }
}
