using Common.Core;
using Domain.Commands;

namespace Core.Services
{
    public interface IExpenseService : IServiceBase
    {
        Task CreateAsync(CreateExpenseCommand command);
    }
}
