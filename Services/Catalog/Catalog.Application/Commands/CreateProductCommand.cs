using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public record CreateProductCommand : IRequest<Guid>
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = String.Empty;
        public Guid BrandId { get; set; }
        public Guid TypeId { get; set; }
        public string ImageFilePath { get; set; } = string.Empty;
        public int ProductCost { get; set; }
        public int GST { get; set; }
        public int ProductTotalCost { get; set; }
    }
}
