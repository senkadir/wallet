using Common.Core;
using Domain.Commands;

namespace Core.Services
{
    public interface IExpenseCategoryService : IServiceBase
    {
        Task CreateAsync(CreateExpenseCategoryCommand command);
    }
}
