using AspDotNetCoreWebAPISwaggerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreWebAPISwaggerUI.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products;

        public ProductService()
        {
            products = new List<Product>();
            for (var i = 0; i < 5; i++)
            {
                products.Add(new Product
                {
                    ProductID = Guid.NewGuid(),
                    ProductCode = "CODE" + i,
                    ProductName = "Product" + i
                });
            }
        }

        public Product GetProductByID(Guid productID)
        {
            return products.SingleOrDefault(x => x.ProductID == productID);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool UpdayteProduct(Product product)
        {
            if (GetProductByID(product.ProductID) == null)
                return false;

            var index = products.FindIndex(x => x.ProductID == product.ProductID);
           
            products[index] = product;

            return true;
        }
    }
}
