using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK__Products__3213E83F40A9AA0A");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.ProductName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(e => e.Price)
            .HasColumnType("int");

        builder
            .Property(e => e.Quantity)
            .HasColumnType("int");

        builder.Property(e => e.Comment)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .HasOne(d => d.Order)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.IdOrderFk);
            //.OnDelete(DeleteBehavior.ClientSetNull)
            //.HasConstraintName("FK__Products__IdOrde__4BAC3F29");
    }
}
