using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendly.Application.Features.Queries.GetAppointmentList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calendy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name ="GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AppointmentList>>> GetAllAppointments()
        {
            var dtos = await _mediator.Send(new GetAppointmentListQuery());

            return Ok(dtos);

        }
    }
}