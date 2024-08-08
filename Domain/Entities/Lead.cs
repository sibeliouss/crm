using Core.Entities;

namespace Domain.Entities;

public class Lead : Entity
{
    public Lead(
        string firstName,
        string lastName,
        string email,
        string phone,
        string source) : this()
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        Source = source;
    }
    public Lead()
    {
        CreateDate = DateTime.UtcNow;
    }
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
 
}