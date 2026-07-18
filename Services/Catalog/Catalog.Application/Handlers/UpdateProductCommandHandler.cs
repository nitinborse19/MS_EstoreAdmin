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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly ProductRepository _productRepository;

        public UpdateProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            ProductModel productModel = new ProductModel()
            {
                Id = request.Id,
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                BrandId = request.BrandId,
                TypeId = request.TypeId,
                ImageFilePath = request.ImageFilePath,
                ProductCost = request.ProductCost,
                GST = request.GST,
                ProductTotalCost = CreateTotalCost(request.GST, request.ProductCost),

            };
            this._productRepository.products.Update(productModel);
            await this._productRepository.SaveChangesAsync();
            return true;

        }
        private int CreateTotalCost(int gST, int productCost)
        {
            return productCost + ((productCost * gST) / 100);
        }
    }
}
