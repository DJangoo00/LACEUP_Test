using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("PK__Orders__3213E83F9FB7854A");

        builder
            .Property(e => e.Id)
            .HasColumnName("id");

        builder
            .Property(e => e.CreateDate)
            .HasColumnType("date");

        builder
            .Property(e => e.ItemCount)
            .HasColumnType("int");

        builder
            .Property(e => e.TotalPrice)
            .HasColumnType("int");

        builder
            .Property(e => e.CustomerName)
            .HasColumnType("nvarchar")
            .HasMaxLength(100);
    }
}
