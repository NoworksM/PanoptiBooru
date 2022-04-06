using Microsoft.EntityFrameworkCore;
using PanoptiBooru.Server.Data;
using PanoptiBooru.Server.Repositories.Core;

namespace PanoptiBooru.Server.Repositories;

public class MediaItemRepository : RepositoryBase<MediaItem, Guid>, IMediaItemRepository
{

    public MediaItemRepository(PanoptiBooruContext context) : base(context)
    {
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<MediaItem> GetForTags(HashSet<Guid> tagIds, Sort sort = Sort.Newest)
    {
        var query = from i in Set
            join it in Context.ItemTags
                on i.Id equals it.ItemId
            where tagIds.Contains(it.TagId)
            select i;

        switch (sort)
        {
            case Sort.Newest:
                query = query.OrderBy(i => i.CreatedAt);
                break;
            case Sort.Oldest:
                query = query.OrderByDescending(i => i.CreatedAt);
                break;
            case Sort.Best:
                query = query.OrderByDescending(i => i.LikeCount);
                break;
            case Sort.Worst:
                query = query.OrderBy(i => i.LikeCount);
                break;
            case Sort.Views:
                query = query.OrderByDescending(i => i.ViewCount);
                break;
            case Sort.Unviewed:
                query = query.OrderBy(i => i.ViewCount);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sort), sort, null);
        }

        return query.AsAsyncEnumerable();
    }

    /// <inheritdoc/>
    public IAsyncEnumerable<MediaItem> GetPagedForTags(HashSet<Guid> tagIds, int page, int pageSize, Sort sort = Sort.Newest)
    {
        var query = from i in Set
            join it in Context.ItemTags
                on i.Id equals it.ItemId
            where tagIds.Contains(it.TagId)
            select i;

        switch (sort)
        {
            case Sort.Newest:
                query = query.OrderBy(i => i.CreatedAt);
                break;
            case Sort.Oldest:
                query = query.OrderByDescending(i => i.CreatedAt);
                break;
            case Sort.Best:
                query = query.OrderByDescending(i => i.LikeCount);
                break;
            case Sort.Worst:
                query = query.OrderBy(i => i.LikeCount);
                break;
            case Sort.Views:
                query = query.OrderByDescending(i => i.ViewCount);
                break;
            case Sort.Unviewed:
                query = query.OrderBy(i => i.ViewCount);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sort), sort, null);
        }

        return query.AsAsyncEnumerable();
    }
}
