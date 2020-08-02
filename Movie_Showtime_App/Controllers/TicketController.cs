using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Showtime_App.API_Models;
using Movie_Showtime_App.Core.Models;
using Movie_Showtime_App.Core.Services;

namespace Movie_Showtime_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var tickets = _ticketService.GetAll().ToList();
            return Ok(tickets.ToApiModels());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = _ticketService.Get(id);
                if (ticket == null) return NotFound();
                return Ok(ticket.ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Get", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Tickets tickets)
        {
            try
            {
                return Ok(_ticketService.Add(tickets).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Post", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tickets tickets)
        {
            try
            {
                return Ok(_ticketService.Update(tickets).ToApiModel());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Put", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ticketService.Remove(id);
                return Ok();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Delete", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
