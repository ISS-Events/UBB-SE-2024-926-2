using System.Configuration;
using CodeBuddies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;


namespace CodeBuddies.Data
{
    public class DatabaseApplicationContext : DbContext
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
                var connectionString = "Server=tcp:iss924.database.windows.net,1433;Initial Catalog=iss;Persist Security Info=False;User ID=gr924;Password=gR!12345678;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
                .HasOne(q => (q.Category));
            modelBuilder.Entity<Session>()
                .HasOne(s => s.DrawingBoard)
                .WithOne()
                .HasForeignKey<Session>(s => s.Id);
            modelBuilder.Entity<Session>()
                .HasOne(s => s.TextEditor)
                .WithOne()
                .HasForeignKey<Session>(s => s.Id);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                foreach (var property in clrType.GetProperties())
                {
                    if (property.PropertyType == typeof(object))
                    {
                        modelBuilder.Entity(clrType).Ignore(property.Name);
                    }
                }
            }
            modelBuilder.Entity<Answer>()
            .HasMany(a => a.Reactions) // Cast Reactions to List<Reaction>
            .WithOne()
            .HasForeignKey("AnswerId") // Use a non-existing property name to represent foreign key
            .IsRequired(false);
        }
        public DbSet<CodeBuddies.Models.Entities.Notification> Notification { get; set; } = default!;
    }
}
