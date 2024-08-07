using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Id).HasDefaultValueSql("NEWID()");
        builder.Property(c => c.Name).HasMaxLength(128);
        builder.Property(c => c.Email).HasMaxLength(64);
        builder.Property(c => c.Phone).HasMaxLength(32);
        builder.Property(c => c.Address).HasMaxLength(256);
        builder.Property(c => c.CreateDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        builder.Property(c => c.UpdateDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
        builder.HasMany(c => c.Contacts).WithOne().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Cascade);// bir Customer kaydı silindiğinde, bu Customer ile ilişkili olan tüm Contact kayıtları da otomatik olarak silinir. 
        builder.HasMany(c => c.Opportunities).WithOne().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.Activities).WithOne().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Cascade);

    }
}