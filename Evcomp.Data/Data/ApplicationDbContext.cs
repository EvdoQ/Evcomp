using Evcomp.API.Configuration;
using Evcomp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Evcomp.API.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComputerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ComputerEntity> Computers { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}
