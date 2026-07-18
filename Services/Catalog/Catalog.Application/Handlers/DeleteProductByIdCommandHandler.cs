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
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private ProductRepository _productRepository;

        public DeleteProductByIdCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            ProductModel? productModel = await this._productRepository.products.Where(e => e.Id == request.Id).FirstOrDefaultAsync();
            if (productModel == null) 
            {
                throw new Exception("Product Not found");
            }
            this._productRepository.products.Remove(productModel);
            await this._productRepository.SaveChangesAsync();

            return true;
        }
    }
}
