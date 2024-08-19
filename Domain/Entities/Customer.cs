using Core.Entities;

namespace Domain.Entities;

public class Customer : Entity
{
    public Customer(
        string name,
        string email,
        string phone,
        string address) : this()
    {
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }

    public Customer()
    {
        CreateDate = DateTime.Now;
        
    }
    
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
   
}