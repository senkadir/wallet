using Wallet.Common.Domain;

namespace Domain.Objects
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
