using Evcomp.API.Data;
using Evcomp.Data.IRepositories;
using Evcomp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evcomp.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IComputerRepository, ComputerRepository>();
            serviceCollection.AddScoped<IAuthRepository, AuthRepository>();
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultDbConnection"));
            });
            return serviceCollection;
        }
    }
}
