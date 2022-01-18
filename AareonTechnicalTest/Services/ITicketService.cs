using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Services
{
    public interface ITicketService
    {
        Task<Ticket> CreateAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> ReadAsync();
        Task<Ticket> ReadByIdAsync(int id);
        Task<Ticket> UpdateAsync(int id, Ticket ticket);
        Task DeleteAsync(int id);
    }
}
