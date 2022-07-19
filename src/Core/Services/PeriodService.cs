using Data;
using Domain.Commands;
using Domain.Models;
using Domain.Objects;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class PeriodService : IPeriodService
    {
        private readonly ApplicationContext _context;

        public PeriodService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreatePeriodCommand command)
        {
            Period period = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                From = command.From,
                To = command.To
            };

            _ = _context.Periods!.Add(period);

            await _context.SaveChangesAsync();
        }

        public async Task<List<PeriodViewModel>> GetAsync()
        {
            return await _context.Periods
                                 .Select(x => new PeriodViewModel
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     From = x.From,
                                     To = x.To
                                 })
                                 .ToListAsync();
        }
    }
}
