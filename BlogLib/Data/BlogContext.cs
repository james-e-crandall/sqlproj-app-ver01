using Microsoft.EntityFrameworkCore;

namespace BlogLib.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogHeader> BlogHeaders { get; set; }
    public DbSet<BlogFooter> BlogFooters { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasMany(e => e.Posts)
            .WithOne(e => e.Blog)
            .HasForeignKey(e => e.BlogId)
            .IsRequired();

        modelBuilder.Entity<Blog>()
            .HasOne(e => e.Header)
            .WithOne(e => e.Blog)
            .HasForeignKey<BlogHeader>(e => e.BlogId)
            .IsRequired();

        modelBuilder.Entity<Blog>()
            .HasOne(e => e.Footer)
            .WithOne(e => e.Blog)
            .HasForeignKey<BlogFooter>(e => e.BlogId)
            .IsRequired(false);

        modelBuilder.Entity<Post>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Posts)
            .UsingEntity<PostTag>();

    }
}