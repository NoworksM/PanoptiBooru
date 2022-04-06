using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanoptiBooru.Server.Data;

public class MediaItem
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int LikeCount { get; set; }
    public int ViewCount { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public virtual ICollection<ItemTag> Tags { get; set; } = new List<ItemTag>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<ItemView> Views { get; set; } = new List<ItemView>();
}
