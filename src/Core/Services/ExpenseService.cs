using Data;
using Domain.Commands;
using Domain.Objects;

namespace Core.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationContext _context;

        public ExpenseService(ApplicationContext context)
        {
            _context = context;
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
    }
}
