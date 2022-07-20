using Common.Core;
using Domain.Commands;
using Domain.Models;

namespace Core.Services
{
    public interface IPeriodService : IServiceBase
    {
        Task CreateAsync(CreatePeriodCommand command);
        Task<List<PeriodViewModel>> GetAsync();
    }
}
