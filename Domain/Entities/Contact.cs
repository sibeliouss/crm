using Core.Entities;

namespace Domain.Entities;

public class Contact : Entity<Guid>
{
    public Contact(
        Customer customer,
        string firstName,
        string lastName,
        string email,
        string phone) : this()
    {
        Customer = customer;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    protected Contact()
    {
        CreateDate = DateTime.Now;
    }
    
    public Customer Customer { get; set; } = new Customer();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

}