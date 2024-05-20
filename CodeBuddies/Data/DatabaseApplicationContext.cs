using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Data
{
    internal class DatabaseApplicationContext : DbContext
    {
        public DatabaseApplicationContext(DbContextOptions<DatabaseApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<Buddy> Buddies { get; set; }
        public DbSet<CodeContribution> CodeContributions { get; set; }
        public DbSet<CodeReviewSection> CodeReviewSections { get; set; }
        public DbSet<DrawingBoard> DrawingBoards { get; set; }
        public DbSet<InfoNotification> InfoNotifications { get; set; }
        public DbSet<InviteNotification> InviteNotifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<TextEditor> TextEditors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity filters and constraints here
        }
    }
}
