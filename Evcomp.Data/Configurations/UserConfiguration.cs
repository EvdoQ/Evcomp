using Evcomp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Evcomp.API.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(c => c.Id);
            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.ComputerId);
        }
    }
}
