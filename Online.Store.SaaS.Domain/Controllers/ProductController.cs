using Microsoft.AspNetCore.Mvc;
using Online.Store.SaaS.Domain.Dtos;
using Online.Store.SaaS.Domain.Models.Contracts;
using Online.Store.SaaS.Domain.Models.Domains;

namespace Online.Store.SaaS.Domain.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> Get()
        {
            var getProductDtos = new List<GetProductDto>();
            var products = await _productRepository.Select();
            foreach (var item in products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    UnitPrice = item.UnitPrice,
                    Description = item.Description,

                };
                getProductDtos.Add(getProductDto);
            }

            return new JsonResult(products);
        }
        [HttpPost(Name = "PostProduct")]
        public async Task<IActionResult> Post(InsertProductDto insertProductDto)
        {
            if (insertProductDto != null)
            {
                var product = new Product()
                {

                    Title = insertProductDto.Title,
                    Description = insertProductDto.Description,
                    UnitPrice = insertProductDto.UnitPrice
                };
                await _productRepository.InsertAsync(product);
            }

            return Ok();
        }
        [HttpPut(Name = "PutProduct")]
        public async Task<IActionResult> Put(UpdateProductDto updateProductDto)
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
               await _productRepository.UpdateAsync(product);
            }

            return Ok();
        }
        [HttpDelete(Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto != null)
            {
                await _productRepository.DeleteAsync(deleteProductDto.Id);
            }

            return Ok();
        }
    }
}
