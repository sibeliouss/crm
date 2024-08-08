using Microsoft.EntityFrameworkCore;

namespace Domain.Pages;

public class PagedList<T>(IEnumerable<T> collection, PagingMetadata metadata) : List<T>(collection), IPagedList<T>
{
    public PagingMetadata Metadata { get; } = metadata;
}

public static partial class QueryableExtensions
{
    public static async Task<IPagedList<T>> ToListAsync<T>(
        this IQueryable<T> source, int pageSize, int pageNumber) where T : class
    {
        if (pageSize < 1)
        {
            throw new ArgumentException("PageSize cannot be less than 1", nameof(pageSize));
        }

        if (pageNumber < 1)
        {
            throw new ArgumentException("PageNumber cannot be less than 1", nameof(pageNumber));
        }

        var itemCount = await source.LongCountAsync();
        var skipCount = (pageNumber - 1) * pageSize;

        var items = (pageSize == int.MaxValue && pageNumber == 1)
            ? await source.ToListAsync()
            : await source.Skip(skipCount).Take(pageSize).ToListAsync();

        var metadata = new PagingMetadata(pageSize, pageNumber, itemCount);

        return new PagedList<T>(items, metadata);
    }
}