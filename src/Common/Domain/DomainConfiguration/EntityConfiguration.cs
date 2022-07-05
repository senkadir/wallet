using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Common.Domain.DomainConfiguration
{
    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uniqueidentifier");

            builder.Property(x => x.CreatedAt)
                   .HasColumnName("CreatedAt")
                   .HasColumnType("datetime");

            builder.Property(x => x.ModifiedAt)
                   .HasColumnName("ModifiedAt")
                   .HasColumnType("datetime");

        }
    }
}
