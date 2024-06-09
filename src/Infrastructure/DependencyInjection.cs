using System;
using FinalProject14231.Application.BikeRentals;
using FinalProject14231.Application.Common.Interfaces;
using FinalProject14231.Domain.Constants;
using FinalProject14231.Domain.Repositories;
using FinalProject14231.Infrastructure.Data;
using FinalProject14231.Infrastructure.Data.Interceptors;
using FinalProject14231.Infrastructure.Identity;
using FinalProject14231.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntityInterceptor>();
        services.AddScoped<DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
        {
            options.UseSqlite(configuration.GetConnectionString("RentalDb"))
                   .AddInterceptors(
                       serviceProvider.GetRequiredService<AuditableEntityInterceptor>(),
                       serviceProvider.GetRequiredService<DispatchDomainEventsInterceptor>());
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddHttpContextAccessor();
        services.AddTransient<IUser, UserService>();
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        services.AddApplicationServices();


        return services;
    }
}
