using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AareonTechnicalTest.Data;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;

        }

        // GET: api/<TicketController>
        [HttpGet]
        public async Task<IEnumerable<Ticket>> GetAsync()
        {
            return await _ticketService.ReadAsync();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ticket = await _ticketService.ReadByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
        

        // CREATE api/<TicketController>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Ticket ticket)
        {
            ticket = await _ticketService.CreateAsync(ticket);

            return Ok(ticket);
        }

        // UPDATE api/<TicketController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Ticket ticket)
        {
            var ticketEntity = await _ticketService.ReadByIdAsync(id);

            if (ticketEntity == null)
            {
                return NotFound();
            }

            ticketEntity = await _ticketService.UpdateAsync(id, ticket);

            return Ok(ticketEntity);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketEntity = await _ticketService.ReadByIdAsync(id);

            if (ticketEntity == null)
            {
                return NotFound();
            }

            await _ticketService.DeleteAsync(id);

            return Ok(ticketEntity);
        }

    }
}
