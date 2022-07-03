using System;

namespace Wallet.Common.Domain
{
    public interface IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
