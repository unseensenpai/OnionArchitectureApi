using OnionSolution.Application.Repositories.OrderRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository(OnionSolutionEFDbContext context) : ReadRepository<Order>(context), IOrderReadRepository
    {
    }
}
