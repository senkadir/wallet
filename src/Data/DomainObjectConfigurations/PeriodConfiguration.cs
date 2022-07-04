using Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Common.Domain.DomainConfiguration;

namespace Data.DomainObjectConfigurations
{
    internal class PeriodConfiguration : AuditableEntityConfiguration<Period>
    {
        public override void Configure(EntityTypeBuilder<Period> builder)
        {
            base.Configure(builder);

            builder.ToTable("Periods");

            builder.Property(x => x.Name)
                   .HasMaxLength(100);
        }
    }
}
