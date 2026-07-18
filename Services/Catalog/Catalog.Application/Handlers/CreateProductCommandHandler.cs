using Catalog.Application.Commands;
using Catalog.Core.Models;
using Catalog.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ProductRepository _productRepository;

        public CreateProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ProductModel productModel = new ProductModel()
            {
                Id = new Guid(),
                ProductName= request.ProductName,
                ProductDescription = request.ProductDescription,
                TypeId= request.TypeId,
                ImageFilePath = request.ImageFilePath,
                GST = request.GST,
                ProductCost = request.ProductCost,
                ProductTotalCost = CreateTotalCost(request.GST,request.ProductCost),
            };
            this._productRepository.products.Add(productModel);
            await this._productRepository.SaveChangesAsync();
            return productModel.Id;
        }

        /// <summary>
        /// This method is used to calculate totalcost of the product including GST
        /// </summary>
        /// <param name="gST"></param>
        /// <param name="productCost"></param>
        /// <returns></returns>
        private int CreateTotalCost(int gST, int productCost)
        {
            return productCost + ((productCost * gST) / 100);
        }
    }
}
