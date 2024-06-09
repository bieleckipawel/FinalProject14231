using System.Reflection;
using FinalProject14231.Application.BikeRentals;
using FinalProject14231.Application.Common.Behaviours;
using FinalProject14231.Application.Services;
using FinalProject14231.Domain.Repositories;
using FinalProject14231.Domain.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });
        services.AddScoped<IBikeService, BikeService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IRentalService, RentalService>();
        services.AddScoped<IBikeRepository, BikeRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();

        return services;
    }
}
