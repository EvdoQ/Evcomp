using Evcomp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evcomp.API.Configuration
{
    public class ComputerConfiguration : IEntityTypeConfiguration<ComputerEntity>
    {
        public void Configure(EntityTypeBuilder<ComputerEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Computer)
                .HasForeignKey(o => o.ComputerId);
        }
    }
}
