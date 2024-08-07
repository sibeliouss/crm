namespace Core.Entities;

public abstract class Entity<TId>: IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}