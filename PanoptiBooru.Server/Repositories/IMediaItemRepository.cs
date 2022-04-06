using PanoptiBooru.Server.Data;
using PanoptiBooru.Server.Repositories.Core;

namespace PanoptiBooru.Server.Repositories;

public interface IMediaItemRepository : IRepository<MediaItem, Guid>
{
    /// <summary>
    /// Get MediaItems for a set of tags
    /// </summary>
    /// <param name="tagIds">Set of tag ids to get items for</param>
    /// <param name="sort">Sort method</param>
    /// <returns>Async enumerable of the items</returns>
    IAsyncEnumerable<MediaItem> GetForTags(HashSet<Guid> tagIds, Sort sort = Sort.Newest);

    /// <summary>
    /// Get a page of MediaItems for a set of tags
    /// </summary>
    /// <param name="tagIds">Set of tag ids to get items for</param>
    /// <param name="page">Page to get</param>
    /// <param name="pageSize">Size of the page</param>
    /// <param name="sort">Sort method</param>
    /// <returns>Async enumerable of the items for the page</returns>
    IAsyncEnumerable<MediaItem> GetPagedForTags(HashSet<Guid> tagIds, int page, int pageSize, Sort sort = Sort.Newest);
}
