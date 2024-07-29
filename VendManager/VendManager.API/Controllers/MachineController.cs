using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Features.Machines.Query.GetAllMachines;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;
using VendManager.Application.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MachineController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public MachineController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MachineController>
        [HttpGet]
        public async Task<List<MachineDto>> Get()
        {
            var machines = await _mediator.Send(new GetMachineQuery());

            return machines;
        }

        [HttpGet]
        [Route("GetAllMachinesWithSensorDetails")]
        public async Task<List<GetAllMachinesWithSensorDetailsDto>> GetMachinesWithSensorDetails()
        {
            var machines = await _mediator.Send(new GetAllMachinesWithSensorDetailsQuery());

            return machines;
        }

        // GET api/<MachineController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MachineController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MachineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MachineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
