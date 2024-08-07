using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public sealed class AppUser : IdentityUser<Guid>
{
    public AppUser()
    {
        Id = Guid.NewGuid();
        SecurityStamp = Guid.NewGuid().ToString();
    }

    public AppUser(string userName) : this()
    {
        UserName = userName;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => (FirstName + " " + LastName).Trim();
} 
