using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionSolution.Application.Repositories.CustomerRepository;

namespace OnionSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(
        ICustomerReadRepository customerReadRepository,
        ICustomerWriteRepository customerWriteRepository) : ControllerBase
    {

        [HttpGet]
        public async Task FireException()
        {
            throw new NotImplementedException();
        }
    }
}
