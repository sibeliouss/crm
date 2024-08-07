namespace Core.Entities;

public interface IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}