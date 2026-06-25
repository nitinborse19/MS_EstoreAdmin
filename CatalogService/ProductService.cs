using CatalogModel.Models.ProductModel;
using CatalogModel.Models.ProductModels;
using CatalogModel.ServiceContract;
using CatalogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

       
        public void DeleteProduct(Guid id)
        {
           if(id == Guid.Empty)
            {
                throw new ArgumentNullException("Product Id is not null");
            }
           var product = this._productRepository.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                 throw new ArgumentNullException("Product not found");
            }
            this._productRepository.Products.Remove(product);
            this._productRepository.SaveChanges();

        }

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = this._productRepository.Products.ToList();
            return productModels;
        }

        public void CreateProduct(CreateProductModel createProductModel,string filePath)
        {
            if(createProductModel == null)
            {
                throw new ArgumentNullException("CreateProductModel is not null");
            }
            ProductModel productModel = new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = createProductModel.ProductName,
                ProductDescription = createProductModel.ProductDescription,
                BrandId = createProductModel.BrandId,
                TypeId = createProductModel.TypeId,
                ImageFilePath = filePath,
                ProductCost = createProductModel.ProductCost,
                GST = 18,
                ProductTotalCost = CreateTotalCost(createProductModel.ProductCost)
            };
            this._productRepository.Add(productModel);
            this._productRepository.SaveChanges();
        }

        private int CreateTotalCost(int productCost)
        {
            int gstAmount = (productCost * 18) / 100;
            int _totolcost = productCost + gstAmount;
            return _totolcost;
        }

        public UpdateProductModel GetProductById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("Product Id is not null");
            }
            var product = this._productRepository.Products.FirstOrDefault(p => p.Id == id);

            if(product == null)
            {
                throw new ArgumentNullException("Product not found");
            }

            UpdateProductModel updateProductModel = new UpdateProductModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                BrandId = product.BrandId,
                TypeId = product.TypeId,
                ImageURL = product.ImageFilePath,
                ProductCost = product.ProductCost
            };
            return updateProductModel;
        }

        public void UpdateProduct(UpdateProductModel updateProductModel,string filePath)
        {
            if (updateProductModel == null) 
            {
                throw new ArgumentNullException("Updated Product Model is not null");
            }
            ProductModel model = new ProductModel()
            {
                Id = updateProductModel.Id,
                ProductName = updateProductModel.ProductName,
                ProductDescription = updateProductModel.ProductDescription,
                BrandId = updateProductModel.BrandId,
                TypeId = updateProductModel.TypeId,
                ImageFilePath = filePath,
                ProductCost = updateProductModel.ProductCost,
                GST = 18,
                ProductTotalCost = CreateTotalCost(updateProductModel.ProductCost)

            };

            this._productRepository.Update(model);
            this._productRepository.SaveChanges();
        }

        public string GetProductUrl(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                throw new ArgumentNullException("Product Id is not null");
            }
            ProductModel? product = this._productRepository.Products.FirstOrDefault(p => p.Id == Id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }

            if(product != null)
            {
                this._productRepository.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            return product.ImageFilePath;
        }
    }
}

