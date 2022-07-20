using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Domain.Commands;
using Domain.Models;
using Domain.Objects;
using Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ExpenseService(ApplicationContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateExpenseCommand command)
        {
            Expense expense = new()
            {
                Id = Guid.NewGuid(),
                PeriodId = command.PeriodId,
                CategoryId = command.CategoryId,
                Amount = command.Amount,
                Description = command.Description
            };

            _ = _context.Expenses!.Add(expense);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ExpenseViewModel>> GetAsync(GetExpenseQuery query)
        {
            return await _context.Expenses
                                 .AsNoTracking()
                                 .Where(x => (query.PeriodId == null || x.PeriodId == query.PeriodId)
                                         && (query.PeriodCode == null || x.Period.Code == query.PeriodCode))
                                 .ProjectTo<ExpenseViewModel>(_mapper.ConfigurationProvider)
                                 .ToListAsync();
        }
    }
}
