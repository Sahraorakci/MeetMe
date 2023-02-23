using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
 
        serviceCollection.AddDbContext<MeetMeContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Local"));

        });
        serviceCollection.AddScoped(typeof(IRepository<>),typeof(Repository<>));
    }
}