using CatalogModel.Models.ProductModel;
using CatalogModel.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogModel.ServiceContract
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();

        void DeleteProduct(Guid id);

        void CreateProduct(CreateProductModel createProductModel,string filePath);

        UpdateProductModel GetProductById(Guid id);

        void UpdateProduct(UpdateProductModel updateProductModel,string filePath);

        string GetProductUrl(Guid Id);
    }
}
