using System.ComponentModel.DataAnnotations;

namespace PanoptiBooru.Server.Data;

public class ItemTag
{
    public Guid TagId { get; set; }
    public virtual Tag Tag { get; set; }
    public Guid ItemId { get; set; }
    public virtual MediaItem MediaItem { get; set; }
}
