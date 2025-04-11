using Application.Features.Event.CreateEvent;
using Application.Features.Event.DeleteEvent;
using Application.Features.Event.GetEventById;
using Application.Features.Event.GetEvents;
using Application.Features.Event.UpdateEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {            
            var result = await mediator.Send(new GetEventsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            var result = await mediator.Send(new DeleteEventCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetEventById(string id)
        {
            var result = await mediator.Send(new GetEventByIdQuery(id));
            if (result == null){
                return NotFound();
            }
            return Ok(result);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(string id, [FromBody] UpdateEventCommand command)
        {

        if (id != command.Id)
        {
        return BadRequest("El ID de la URL no coincide con el del cuerpo.");
        }
        try
        {
        var result = await mediator.Send(command);
        return Ok(new { message = "Evento actualizado correctamente", id = result });
        }
        catch (Exception ex)
        {
        return NotFound(new { message = ex.Message });
        }
        }
        }   
        }