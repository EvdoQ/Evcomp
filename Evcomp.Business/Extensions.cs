using Evcomp.API.Configurations;
using Evcomp.API.Models;
using Evcomp.API.Services;
using Evcomp.Business.IServices;
using Evcomp.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evcomp.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<AwsSettings>(configuration.GetSection("AWS"));
            serviceCollection.AddSingleton<IS3Service, S3Service>();
            serviceCollection.AddAutoMapper(typeof(MappingProfile));
            serviceCollection.AddScoped<IComputerService, ComputerService>();
            return serviceCollection;
        }
    }
}
