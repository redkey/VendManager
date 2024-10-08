﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

    }
}
