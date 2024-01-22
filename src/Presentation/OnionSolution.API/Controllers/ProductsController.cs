using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("GetProductById")]
        public async Task<Product> GetProductById(string guid)
        {
            var result = await productReadRepository.GetByIdAsync(guid, false);

            return result;
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

        [HttpPost("AddDummyData")]
        public async Task<IActionResult> AddProducts(int count)
        {
            List<Product> products = GenerateRandomProducts(count);

            var result = await productWriteRepository.AddRangeAsync(products);
            await productWriteRepository.SaveAsync();

            return Ok(result);
        }

        [HttpPut("FixValues")]
        public async Task FixValues()
        {
            Random random = new Random();
            var datas = productReadRepository.GetWhere(x => x.Stock == 150);

            await datas.ForEachAsync(data =>
            {
                data.Stock = Convert.ToInt32(data.Name.Split('-').LastOrDefault()) * random.Next(0, Convert.ToInt32(data.Name.Split('-').LastOrDefault()) * random.Next(1, 10));
                var result = productWriteRepository.Update(data);
            });

            await productWriteRepository.SaveAsync();
        }

        private static List<Product> GenerateRandomProducts(int count)
        {
            Random random = new();
            List<Product> products = [];
            for (int i = 0; i < count; i++)
            {
                products.Add(new()
                {
                    Name = $"ÜrünTest-{i * random.Next(i, random.Next(i, 10))}",
                    Orders = [],
                    Price = i * random.Next(minValue: 1, i * random.Next(1, 10)),
                    Stock = i * random.Next(1, i * random.Next(1, 10))
                });
            }

            return products;
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = productWriteRepository.Update(product);
            var saveResult = await productWriteRepository.SaveAsync();
            return Ok(saveResult);
        }

        [HttpPatch("UpdateById")]
        public async Task<IActionResult> UpdateById(string guid)
        {
            var product = await GetProductById(guid);
            product.Name = "YeniÜrünİsmi";

            _ = productWriteRepository.Update(product);

            var saveResult = await productWriteRepository.SaveAsync();

            return Ok(saveResult);

        }
    }
}
