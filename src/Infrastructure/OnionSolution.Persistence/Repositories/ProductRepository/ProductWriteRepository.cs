using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.ProductRepository
{
    public class ProductWriteRepository(OnionSolutionEFDbContext context) : WriteRepository<Product>(context), IProductWriteRepository
    {
    }
}
