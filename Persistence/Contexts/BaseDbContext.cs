using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Contexts;

public class BaseDbContext: IdentityDbContext<AppUser, AppRole, Guid>
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2); 
        
        builder.ApplyConfiguration(new CustomerConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        
        builder.Ignore<Activity>();
        builder.Ignore<Contact>();
        builder.Ignore<Opportunity>();

        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();
        
        base.OnModelCreating(builder);

    }
}
