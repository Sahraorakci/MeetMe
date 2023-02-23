using System.Reflection;
using Application.Mapper;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        serviceCollection.AddAutoMapper(opt =>
        {
            opt.AddProfiles(new List<Profile>
            {
                new MeetingMapper()
            });
        });
    }
}