using Data;
using Domain.Commands;
using Domain.Objects;

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
    }
}
