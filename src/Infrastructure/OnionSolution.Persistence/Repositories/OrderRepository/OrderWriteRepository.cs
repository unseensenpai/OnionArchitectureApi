using OnionSolution.Application.Repositories.OrderRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository(OnionSolutionEFDbContext context) : WriteRepository<Order>(context), IOrderWriteRepository
    {
    }
}
