using Domain.Objects;
using Microsoft.EntityFrameworkCore;

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
    }
}
