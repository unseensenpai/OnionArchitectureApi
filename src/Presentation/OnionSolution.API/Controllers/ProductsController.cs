using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionSolution.Application.Abstractions;
using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Domain.Entities;

namespace OnionSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
        IProductService productService,
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository) : ControllerBase
    {

        [HttpGet("Get")]
        public IActionResult Get()
        {
            var products = productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("[Action]")]
        public IActionResult GetProducts()
        {
            var result = productReadRepository.GetAll();
            return Ok(result);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await productWriteRepository.AddAsync(product);

            await productWriteRepository.SaveAsync();

            return Ok(result);
        }

        [HttpPost("AddProducts")]
        public async Task<IActionResult> AddProducts(IList<Product> products)
        {
            var result = await productWriteRepository.AddRangeAsync(products);
            await productWriteRepository.SaveAsync();

            return Ok(result);
        }
    }
}
