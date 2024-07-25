using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Features.Sensors.Query;
using VendManager.Application.Features.Sensors.Query.GetAllSensorsWithSameMachine;
using VendManager.Application.Features.Sensors.Query.GetMachineWithSensorDetails;
using VendManager.Application.Models;
using VendManager.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {

        private readonly IMediator _mediator;
        public SensorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<SensorController>
        [HttpGet]
        public async Task<List<MachineDto>>Get()
        {
            var sensors = await _mediator.Send(new GetAllSensorsWithSameMachineQuery());
            return sensors;
        }

        // GET api/<SensorController>/5
        [HttpGet("{id}")]
        public async Task<List<SensorDto>> Get(long id)
        {
            var sensor = await _mediator.Send(new GetMachineWithSensorDetailsQuery() { Id = id });
            return sensor;
        }

        // POST api/<SensorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SensorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SensorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
