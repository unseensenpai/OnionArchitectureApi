using OnionSolution.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Application.Abstractions
{
    public interface IProductService
    {
        IList<Product> GetProducts();
    }
}
