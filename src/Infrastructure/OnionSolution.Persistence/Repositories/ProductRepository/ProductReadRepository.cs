using OnionSolution.Application.Repositories.ProductRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository(OnionSolutionEFDbContext context) : ReadRepository<Product>(context), IProductReadRepository
    {
    }
}
