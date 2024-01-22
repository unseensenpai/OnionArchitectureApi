using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionSolution.Application.Repositories.OrderRepository;
using OnionSolution.Domain.Entities;

namespace OnionSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(
        IOrderReadRepository orderReadRepository,
        IOrderWriteRepository orderWriteRepository) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(Order order)
        {
            var result = await orderWriteRepository.AddAsync(order);
            await orderWriteRepository.SaveAsync();

            return Ok(result);
        }
    }
}
