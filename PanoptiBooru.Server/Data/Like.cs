namespace PanoptiBooru.Server.Data;

public class Like
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public virtual MediaItem Item { get; set; }
}
