using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebAPISwaggerUI.Config.v1;
using AspDotNetCoreWebAPISwaggerUI.Models;
using AspDotNetCoreWebAPISwaggerUI.Models.v1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreWebAPISwaggerUI.Controllers
{
    public class ProductController : Controller
    {
        private List<ProductRequest> products;

        public ProductController()
        {
            products = new List<ProductRequest>();
            for (var i = 0; i < 5; i++)
            {
                products.Add(new ProductRequest { ProductID = Guid.NewGuid().ToString(),
                    ProductCode = "CODE" + i, ProductName = "Product" + i 
                });
            }
        }

        [HttpGet(ApiRoutes.Products.GetAllProducts)]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        [HttpPost(ApiRoutes.Products.SaveAllProducts)]
        public IActionResult SaveAllProducts([FromBody] ProductRequest product)
        {
            if (string.IsNullOrEmpty(product.ProductID))
                product.ProductID = Guid.NewGuid().ToString();

            products.Add(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Products.Save.Replace("{ProductID}", product.ProductID);

            var response = new ProductResponse
            {
                ProductID = product.ProductID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName
            };

            return Created(locationUrl, response);
        }
    }
}