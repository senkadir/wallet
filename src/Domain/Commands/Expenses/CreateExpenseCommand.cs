namespace Domain.Commands
{
    public class CreateExpenseCommand
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public Guid PeriodId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
