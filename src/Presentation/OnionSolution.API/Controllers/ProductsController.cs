using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionSolution.Application.Abstractions;

namespace OnionSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();

            return Ok(products);
        }
    }
}
