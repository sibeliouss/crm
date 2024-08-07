using Core.Entities;

namespace Domain.Entities;

public class Opportunity : Entity<Guid>
{
    public Opportunity(
        Customer customer,
        string description,
        decimal value) : this()
    {
        Customer = customer;
        Description = description;
        Value = value;
    }

    protected Opportunity()
    {
        CreateDate = DateTime.Now;
    }
    
    public Customer Customer { get; set; } = new Customer();
    public string Description { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime CloseDate { get; set; }
   
}