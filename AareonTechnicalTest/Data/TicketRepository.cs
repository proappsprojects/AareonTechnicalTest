using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AareonTechnicalTest.Data
{
    public class TicketRepository: ITicketRepository
    {
        private readonly ApplicationContext _appContext;

        public TicketRepository(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<Ticket> CreateAsync(Ticket ticket)
        {
            _appContext.Tickets.Add(ticket);
            await _appContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> ReadAsync()
        {
            return await _appContext.Tickets.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<Ticket> ReadByIdAsync(int id)
        {
            return await _appContext.Tickets
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ticket> UpdateAsync(Ticket ticket)
        {
            _appContext.Tickets.Update(ticket);
            await _appContext.SaveChangesAsync();
            return ticket;
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await ReadByIdAsync(id);

            if (ticket == null)
            {
                throw new Exception("Unable to find ticket with id '" + id + "'.");
            }

            _appContext.Tickets.Remove(ticket);
            await _appContext.SaveChangesAsync();
        }
    }
}
