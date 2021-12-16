using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AareonTechnicalTest.Data;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;

        }
        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException();
            }
            return  await _ticketRepository.CreateAsync(ticket);
        }

        public async Task<IEnumerable<Ticket>> ReadAsync()
        {
            return await _ticketRepository.ReadAsync();
        }

        public async Task<Ticket> ReadByIdAsync(int id)
        {
            return await _ticketRepository.ReadByIdAsync(id);
        }

        public async Task<Ticket> UpdateAsync(int id, Ticket ticket)
        {
            if (ticket == null || id < 1)
            {
                throw new ArgumentNullException();
            }
            var ticketEntity = await _ticketRepository.ReadByIdAsync(id);

            if (!string.IsNullOrEmpty(ticket.Content)){
                ticketEntity.Content = ticket.Content;
            }
            if (ticket.PersonId > 0)
            {
                ticketEntity.PersonId = ticket.PersonId;
            }

            if (ticketEntity == null)
            {
                throw new KeyNotFoundException("Unable to find ticket record with id '" + ticket.Id + "'.");
            }

            return await _ticketRepository.UpdateAsync(ticketEntity);
            
        }

        public async Task DeleteAsync(int id)
        {
            var ticketEntity = await _ticketRepository.ReadByIdAsync(id);

            if (ticketEntity == null)
            {
                throw new KeyNotFoundException("Unable to find ticket record with id '" + id + "'.");
            }

            await _ticketRepository.DeleteAsync(id);
        }
    }
}
