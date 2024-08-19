using System.Runtime.Serialization;

namespace Core.Entities;

public interface IEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
