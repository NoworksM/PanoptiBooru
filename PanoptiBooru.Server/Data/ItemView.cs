namespace PanoptiBooru.Server.Data;

public class ItemView
{
    public Guid ItemId { get; set; }
    public virtual MediaItem Item { get; set; }
    public Guid UserId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}
