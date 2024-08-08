using Microsoft.AspNetCore.Http;

namespace Domain.Pages;

public record PagingMetadata(int PageSize, int PageNumber, long ItemCount)
{
    public int PageCount { get; } = (int)Math.Ceiling((decimal)ItemCount / PageSize);
    public long RangeStart { get; } = ((PageNumber - 1) * PageSize) + 1;
    public long RangeEnd { get; } = Math.Min(PageNumber * PageSize, ItemCount);

    public override string ToString()
    {
        return $"Page = {PageNumber} of {PageCount} PageSize = {PageSize} " +
               $"Items = {RangeStart} - {RangeEnd} of {ItemCount}";
    }
}

public static class ResponseExtensions
{
    public static void AddPagingHeaders(this HttpResponse response, PagingMetadata metadata)
    {
        response.Headers.Add("X-Paging-PageSize", metadata.PageSize.ToString());
        response.Headers.Add("X-Paging-PageNumber", metadata.PageNumber.ToString());
        response.Headers.Add("X-Paging-PageCount", metadata.PageCount.ToString());
        response.Headers.Add("X-Paging-RangeStart", metadata.RangeStart.ToString());
        response.Headers.Add("X-Paging-RangeEnd", metadata.RangeEnd.ToString());
        response.Headers.Add("X-Paging-ItemCount", metadata.ItemCount.ToString());
    }
}