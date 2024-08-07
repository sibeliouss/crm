using Core.Entities;

namespace Domain.Entities;

public class Activity: Entity<Guid>
{
    public Activity(
        Customer customer,
        string description
    ) : this()
    {
        Customer = customer;
        Description = description;
    }

    protected Activity()
    {
        CreateDate = DateTime.Now;
    }

    public Customer Customer { get; set; } = new Customer();
    public string Description { get; set; } = string.Empty;
 
}