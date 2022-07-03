using System;

namespace Wallet.Common.Domain
{
    public class AuditableEntity : Entity, IAuditable
    {
        public Guid CreatedBy { get; set; }

        public Guid ModifiedBy { get; set; }
    
    }
}
