using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public PeriodService(ApplicationContext context,
                             IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreatePeriodCommand command)
        {
            Period period = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Code = command.Name.Replace(" ", "-").ToLower(),
                From = command.From,
                To = command.To
            };

            _ = _context.Periods!.Add(period);

            _ = await _context.SaveChangesAsync();
        }

        public async Task<List<PeriodViewModel>> GetAsync()
        {
            return await _context.Periods
                                 .AsNoTracking()
                                 .ProjectTo<PeriodViewModel>(_mapper.ConfigurationProvider)
                                 .ToListAsync();
        }
    }
}
