namespace Domain.Queries
{
    public class GetExpenseQuery
    {
        public Guid? PeriodId { get; set; }

        public string? PeriodCode { get; set; }
    }
}
