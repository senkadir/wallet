using System;

namespace Wallet.Common.Domain
{
    public abstract class Entity : IIdentifiable
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
