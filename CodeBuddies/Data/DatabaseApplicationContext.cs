using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Data
{
    internal class DatabaseApplicationContext : DbContext
    {
        public DatabaseApplicationContext(DbContextOptions<DatabaseApplicationContext> options)
        : base(options)
        {
        }
        //public DbSet<> Customers { get; set; }
        //// Other DbSets for your entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity filters and constraints here
        }
    }
}
