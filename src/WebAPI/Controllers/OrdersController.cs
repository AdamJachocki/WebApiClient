using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Models;
using WebAPI.Repo;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersRepository _repo;
        private readonly IMapper _mapper;

        public OrdersController(OrdersRepository repo, IMapper mapper)
        {
            _repo = repo;   
            _mapper = mapper;
        }

        [HttpPost("all")]
        public IActionResult GetOrders([FromBody]GetOrdersRequestDto data)
        {
            var list = _repo.GetOrders(data);
            var dtos = _mapper.Map<IEnumerable<OrderDto>>(list);
            var result = new GetOrdersResultDto(dtos, data.Skip + dtos.Count());
            
            return Ok(result);
        }

        [HttpPost("client/{clientId}")]
        public IActionResult GetOrdersForClient(int clientId, [FromBody]GetOrdersRequestDto data)
        {
            var result = _repo.GetOrdersForClient(clientId, data);
            if (result == null || !result.Any())
                return NotFound();
            else
                return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var result = _repo.GetOrderById(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody]OrderDto data)
        {
            Order model = _mapper.Map<Order>(data);
            data.Id = _repo.AddOrder(model);
            return Created("/", data);
        }
    }
}
