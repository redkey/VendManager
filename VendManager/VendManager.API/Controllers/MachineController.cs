using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendManager.Application.Features.Machines.Query.GetAllMachines;
using VendManager.Application.Features.Machines.Query.GetAllMachinesWithSensorDetails;
using VendManager.Application.Features.Machines.Query.GetMachineDetails;
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

        [HttpGet]
        [Route("GetMachineDetails")]
        public async Task<MachineDetailDto> Get(long machineId)
        {
            var machines = await _mediator.Send(new GetMachineDetailQuery(machineId));

            return machines;
        }


    }
}
