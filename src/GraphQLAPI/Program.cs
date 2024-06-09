using FinalProject14231.Application.Common.Interfaces;
using FinalProject14231.Infrastructure.Data.Interceptors;
using FinalProject14231.Infrastructure.Services;
using FinalProject14231.Infrastructure.Data;
using Microsoft.OpenApi.Models;

namespace GraphQLAPI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IUser, UserService>();
        builder.Services.AddScoped<AuditableEntityInterceptor>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQLAPI", Version = "v1" });
        });

        builder.Services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
            await initializer.InitializeAsync();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.MapGraphQL();

        app.Run();
    }
}
