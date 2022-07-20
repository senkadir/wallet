using Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Wallet.Common.Domain;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ExpenseCategory>? ExpenseCategories { get; set; }

        public DbSet<Expense>? Expenses { get; set; }

        public DbSet<Period>? Periods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataIdentifier).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries()
                         .Where(x => x.State == EntityState.Added && x.Entity is Entity)
                         .ToList()
                         .ForEach(added =>
                         {
                             added.Property("CreatedAt").CurrentValue = DateTime.Now;
                             added.Property("ModifiedAt").CurrentValue = DateTime.Now;
                         });

            ChangeTracker.Entries()
                         .Where(x => x.State == EntityState.Modified && x.Entity is Entity)
                         .ToList()
                         .ForEach(added =>
                         {
                             added.Property("ModifiedAt").CurrentValue = DateTime.Now;
                         });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
