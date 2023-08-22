using Microsoft.AspNetCore.Mvc;
using Online.Store.SaaS.Domain.Dtos;
using Online.Store.SaaS.Domain.Models.Contracts;
using Online.Store.SaaS.Domain.Models.Domains;

namespace Online.Store.SaaS.Domain.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        [HttpGet(Name = "GetProducts")]
        public IActionResult Get()
        {
            var products = _productRepository.Select().Result;
            return new JsonResult(products);
        }
        [HttpPost(Name = "PostProduct")]
        public IActionResult Post(InsertProductDto insertProductDto)
        {
            if (insertProductDto != null)
            {
                var product = new Product()
                {

                    Title = insertProductDto.Title,
                    Description = insertProductDto.Description,
                    UnitPrice = insertProductDto.UnitPrice,
                };
                _productRepository.InsertAsync(product);
            }

            return Ok();
        }
        [HttpPut(Name = "PutProduct")]
        public IActionResult Put(UpdateProductDto updateProductDto)
        {
            if (updateProductDto != null)
            {
                var product = new Product()
                {
                    Id = updateProductDto.Id,
                    Title = updateProductDto.Title,
                    Description = updateProductDto.Description,
                    UnitPrice = updateProductDto.UnitPrice,
                };
                _productRepository.UpdateAsync(product);
            }

            return Ok();
        }
        [HttpDelete(Name = "DeleteProduct")]
        public IActionResult Delete(DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto != null)
            {
                _productRepository.DeleteAsync(deleteProductDto.Id);
            }

            return Ok();
        }
    }
}
