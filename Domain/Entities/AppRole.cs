using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

//sealed: bir sınıfın miras alınmasını engellemek için kullanılır. Bu, sınıfın güvenliğini sağlamak için kullanılır.

public sealed class AppRole : IdentityRole<Guid>
{
    public AppRole()
    {
        Id = Guid.NewGuid();
    }

    public AppRole(string roleName) : this()
    {
        Name = roleName;
    }
}

public sealed class AppRoleClaim : IdentityRoleClaim<Guid> { }

public sealed class AppUserRole : IdentityUserRole<Guid> { }