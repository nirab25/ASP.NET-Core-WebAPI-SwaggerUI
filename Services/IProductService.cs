using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AspDotNetCoreWebAPISwaggerUI.Models;

namespace AspDotNetCoreWebAPISwaggerUI.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductByID(Guid productID);
        public bool UpdayteProduct(Product product);
    }
}
