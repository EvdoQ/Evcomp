using Evcomp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evcomp.API.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder
                .HasOne(o => o.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.UserId);
            builder
                .HasOne(o => o.Computer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ComputerId);
        }
    }
}
