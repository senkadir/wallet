using Wallet.Common.Domain;

namespace Domain.Objects
{
    public class Expense : AuditableEntity
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public Guid PeriodId { get; set; }

        public Guid CategoryId { get; set; }

        public Period Period { get; set; }

        public ExpenseCategory Category { get; set; }
    }
}
