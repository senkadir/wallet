using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Common.Domain.DomainConfiguration
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .HasColumnType("uuid");

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("create_at")
                   .HasColumnType("timestamp");

            builder.Property(x => x.ModifiedAt)
                   .HasColumnName("modified_at")
                   .HasColumnType("timestamp");

        }
    }
}
