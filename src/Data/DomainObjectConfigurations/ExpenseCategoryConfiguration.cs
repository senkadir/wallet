using Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Common.Domain.DomainConfiguration;

namespace Data.DomainObjectConfigurations
{
    internal class ExpenseCategoryConfiguration : AuditableEntityConfiguration<ExpenseCategory>
    {
        public override void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("ExpenseCategories");

            builder.Property(x => x.Name)
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(250);
        }
    }
}
