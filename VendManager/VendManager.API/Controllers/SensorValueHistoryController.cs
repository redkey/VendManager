using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistory;
using VendManager.Application.Features.SensorValueHistory.Query.GetAllSensorValueHistoryById;
using VendManager.Application.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SensorValueHistoryController : ControllerBase
    {


        private readonly IMediator _mediator;

        public SensorValueHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SensorValueHistoryController>
        [HttpGet]
        public async Task<List<SensorValueHistoryDto>> Get()
        {
            var sensorValue = await _mediator.Send(new GetAllSensorValueHistoryQuery());
            return sensorValue;
        }

        // GET api/<SensorValueHistoryController>/5
        [HttpGet("{id}")]
        public async Task<List<SensorValueHistoryDto>> Get(long id)
        {
           var sensorValue = await _mediator.Send(new GetAllSensorValueHistoryByIdQuery(id));
            return sensorValue;
        }

    }
}
