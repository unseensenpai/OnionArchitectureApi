﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using OnionSolution.Application.Abstractions;
using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Domain.Entities.Common;
using OnionSolution.Domain.Entities.Products;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnionSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
        IProductService productService,
        IProductReadRepository productReadRepository,
        IProductWriteRepository productWriteRepository,
        ICachedProductRepository cache) : ControllerBase
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

        [HttpPost("GetAllProducts")]
        public IActionResult GetAllProducts([FromBody, Required] PagedSearchParameters pagedSearchParameters)
        {
            var result = productReadRepository.GetAll(pagedSearchParameters);
            return Ok(result);
        }



        [HttpGet("GetProductById")]
        public async Task<Product> GetProductById(string guid)
        {

            var cachedResult = await cache.GetByIdAsync(guid);

            //var result = await productReadRepository.GetByIdAsync(guid, false);

            return cachedResult;
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
                ProductFaker productFaker = new();
                var fakeData = productFaker.Generate();

                products.Add(new()
                {
                    Name = $"ÜrünTest-{fakeData.Name}",
                    Orders = [],
                    Price = fakeData.Price,
                    Stock = fakeData.Stock
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
