using System;

namespace Wallet.Common.Domain
{
    public interface IAuditable
    {
        Guid CreatedBy { get; set; }

        Guid ModifiedBy { get; set; }
    }
}
