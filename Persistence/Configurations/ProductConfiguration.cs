using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
        builder.Property(p => p.Name).HasMaxLength(128);
        builder.Property(p => p.Description).HasMaxLength(256);
        builder.Property(p => p.CreateDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        builder.Property(p => p.UpdateDate).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
    }
}