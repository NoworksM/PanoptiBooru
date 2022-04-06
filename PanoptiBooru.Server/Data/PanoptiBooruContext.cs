using Microsoft.EntityFrameworkCore;

namespace PanoptiBooru.Server.Data;

public class PanoptiBooruContext : DbContext
{
#pragma warning disable CS8618
    public PanoptiBooruContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618
    {
    }

    public DbSet<MediaItem> MediaItems { get; set; }
    public DbSet<ItemTag> ItemTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Namespace> Namespaces { get; set; }
    public DbSet<Like> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ItemTag>()
            .HasKey(e => new {e.TagId, e.ItemId});

        modelBuilder
            .Entity<Like>()
            .HasKey(e => new { e.ItemId, e.UserId });
    }
}
