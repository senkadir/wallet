using Data;
using Domain.Queries.Reports;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationContext _applicationContext;

        public ReportService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task GetByPeriod(ReportByPeriodQuery query)
        {
            var result = await _applicationContext.Expenses
                                            .AsNoTracking()
                                            .Where(x => x.Period.Code == query.PeriodCode)
                                            .SumAsync(x => x.Amount);

        }
    }
}
