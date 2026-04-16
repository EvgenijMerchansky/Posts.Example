using Microsoft.EntityFrameworkCore;
using Posts.Example.DBLayer.Models;

namespace Posts.Example.DBLayer.EntityFramework;

public class PostsDbContext(DbContextOptions<PostsDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.UserId).IsRequired();
            entity.Property(x => x.Title).HasMaxLength(500);
            entity.Property(x => x.Body).HasMaxLength(8000);
        });
    }
}
