using CodeBuddies.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuddiesApi.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
        : base(options)
        {
        }



        public DbSet<Category> Categories { get; set; } = null!;
    }
}
