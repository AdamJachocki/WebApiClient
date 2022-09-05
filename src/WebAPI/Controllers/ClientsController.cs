using AutoMapper;
using Common;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebAPI.Models;
using WebAPI.Repo;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsRepository _repo;
        private readonly IMapper _mapper;

        public ClientsController(ClientsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("all")]
        public IActionResult GetClients([FromBody]GetClientsRequestDto data)
        {
            var list = _repo.GetClients(data);
            var dtos = _mapper.Map<IEnumerable<ClientDto>>(list);
            var result = new GetClientsResultDto(dtos, data.Skip + dtos.Count());
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            var result = _repo.GetClientById(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        public IActionResult AddClient([FromBody] ClientDto data)
        {
            Client model = _mapper.Map<Client>(data);
            data.Id = _repo.AddClient(model);
            return Created("/", data);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveClient(int id)
        {
            var result = _repo.DeleteClient(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
