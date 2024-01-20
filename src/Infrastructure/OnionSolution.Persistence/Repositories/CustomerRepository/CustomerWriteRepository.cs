using OnionSolution.Application.Repositories.CustomerRepository;
using OnionSolution.Domain.Entities;
using OnionSolution.Persistence.Contexts;

namespace OnionSolution.Persistence.Repositories.CustomerRepository
{
    public class CustomerWriteRepository(OnionSolutionEFDbContext context) : WriteRepository<Customer>(context), ICustomerWriteRepository
    {
    }
}
