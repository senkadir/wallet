using Data;
using Domain.Commands;
using Domain.Objects;

namespace Core.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly ApplicationContext _context;

        public ExpenseCategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateExpenseCategoryCommand command)
        {
            ExpenseCategory expenseCategory = new()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                IsActive = true
            };

            _ = _context.ExpenseCategories!.Add(expenseCategory);

            _ = await _context.SaveChangesAsync();
        }
    }
}
