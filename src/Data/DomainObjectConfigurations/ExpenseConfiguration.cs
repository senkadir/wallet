using Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Common.Domain.DomainConfiguration;

namespace Data.DomainObjectConfigurations
{
    internal class ExpenseConfiguration : AuditableEntityConfiguration<Expense>
    {
        public override void Configure(EntityTypeBuilder<Expense> builder)
        {
            base.Configure(builder);

            builder.ToTable("Expenses");

            builder.Property(x => x.Description)
                   .HasMaxLength(250);
        }
    }
}
