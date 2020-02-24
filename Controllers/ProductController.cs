using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebAPISwaggerUI.Config.v1;
using AspDotNetCoreWebAPISwaggerUI.Models;
using AspDotNetCoreWebAPISwaggerUI.Models.v1.Requests;
using AspDotNetCoreWebAPISwaggerUI.Models.v1.Responses;
using AspDotNetCoreWebAPISwaggerUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetCoreWebAPISwaggerUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly  IProductService productService;
        public ProductController(IProductService pService)
        {
            productService = pService;
        }

        [HttpGet(ApiRoutes.Products.GetAllProducts)]
        public IActionResult GetAllProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet(ApiRoutes.Products.Retrieve)]
        public IActionResult GetProduct([FromRoute] Guid productID)
        {
            var product = productService.GetProductByID(productID);


            if (product == null)
                return NotFound("Requested product not found!");

            return Ok(product);
        }

        [HttpPut(ApiRoutes.Products.Update)]
        public IActionResult UpdateProduct([FromRoute] Guid productID, [FromBody] UpdateProductRequest request)
        {
            var product = new Product
            {
                ProductID = productID,
                ProductCode = request.ProductCode,
                ProductName = request.ProductName
            };

            if(!productService.UpdayteProduct(product))
                return NotFound("Requested product not found!");

            return Ok(product);
        }

        [HttpPost(ApiRoutes.Products.Save)]
        public IActionResult SaveProduct([FromBody] ProductRequest productRequest)
        {
            if (productRequest.ProductID == null)
                productRequest.ProductID = Guid.NewGuid();

            Product product = new Product
            {
                ProductID = productRequest.ProductID,
                ProductCode = productRequest.ProductCode,
                ProductName = productRequest.ProductName
            };

            productService.GetProducts().Add(product);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Products.Save.Replace("{ProductID}", product.ProductID.ToString());

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