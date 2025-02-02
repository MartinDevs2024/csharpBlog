using csharpBlog.Models;
using csharpBlog.Models.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace csharpBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppUser> AppUsers { get; set;}
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set;}

        public DbSet<MainComment> MainComments { get; set; }

        public DbSet<SubComment> SubComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.AppUserId);
        }
    }
}