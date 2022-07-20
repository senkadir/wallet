using Data;
using Domain.Queries.Reports;

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
        }
    }
}
