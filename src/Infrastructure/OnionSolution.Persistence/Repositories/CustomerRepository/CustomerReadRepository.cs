using OnionSolution.Application.Repositories.CustomerRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.CustomerRepository
{
    public class CustomerReadRepository(OnionSolutionEFDbContext context) : ReadRepository<Customer>(context), ICustomerReadRepository
    {
    }
}
