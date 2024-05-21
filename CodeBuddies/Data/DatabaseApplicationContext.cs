using System.Configuration;
using CodeBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeBuddies.Data
{
    internal class DatabaseApplicationContext : DbContext
    {
        public DatabaseApplicationContext()
        {
        }
        public DatabaseApplicationContext(DbContextOptions<DatabaseApplicationContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Buddy> Buddies { get; set; }
        public DbSet<CodeContribution> CodeContributions { get; set; }
        public DbSet<CodeReviewSection> CodeReviewSections { get; set; }

        public DbSet<DrawingBoard> DrawingBoards { get; set; }
        public DbSet<InfoNotification> InfoNotifications { get; set; }
        public DbSet<InviteNotification> InviteNotifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TextEditor> TextEditors { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity filters and constraints here
            modelBuilder.Entity<Question>()
                .HasOne<Category>(q => (Category)q.Category);
            modelBuilder.Entity<Session>()
                .HasOne<DrawingBoard>(s => (DrawingBoard)s.DrawingBoard)
                .WithOne()
                .HasForeignKey<Session>(s => s.Id);
            modelBuilder.Entity<Session>()
                .HasOne<TextEditor>(s => (TextEditor)s.TextEditor)
                .WithOne()
                .HasForeignKey<Session>(s => s.Id);
        }
    }
}
