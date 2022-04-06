using System.ComponentModel.DataAnnotations;

namespace PanoptiBooru.Server.Data;

public class Tag
{
    [Key]
    public Guid Id { get; set; }
    public string Value { get; set; }
    public Guid? NamespaceId { get; set; }
    public virtual Namespace Namespace { get; set; }
    public Guid? ParentTagId { get; set; }
    public virtual Tag ParentTag { get; set; }
    public virtual ICollection<ItemTag> ItemTags { get; set; }
}
