using Common.Core;
using Domain.Commands;

namespace Core.Services
{
    public interface IPeriodService : IServiceBase
    {
        Task CreateAsync(CreatePeriodCommand command);
    }
}
