using Wallet.Common.Domain;

namespace Domain.Objects
{
    public class Period : AuditableEntity
    {
        public string Name { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public List<Expense> Expenses { get; set; }
    }
}
