using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Common.Domain.DomainConfiguration
{
    public abstract class AuditableEntityConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("UNIQUEIDENTIFIER");
        }
    }
}
