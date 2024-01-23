using OnionSolution.Application.Abstractions;
using OnionSolution.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public IList<Product> GetProducts()
        {
            List<Product> products = new()
            {
                new()
                {
                    Name = "Ürün1",
                    Price = 50,
                    Stock = 10
                },
                new()
                {
                    Name = "Ürün2",
                    Price = 50,
                    Stock = 10
                }
            };

            return products;
        }
    }
}
