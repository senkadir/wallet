using Common.Core;
using Domain.Commands;
using Domain.Models;
using Domain.Queries;

namespace Core.Services
{
    public interface IExpenseService : IServiceBase
    {
        Task CreateAsync(CreateExpenseCommand command);
        Task<List<ExpenseViewModel>> GetAsync(GetExpenseQuery query);
    }
}
