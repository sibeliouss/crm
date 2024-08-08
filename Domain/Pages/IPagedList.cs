namespace Domain.Pages;

public interface IPagedList<T> : IList<T>
{
    public PagingMetadata Metadata { get; }
}
