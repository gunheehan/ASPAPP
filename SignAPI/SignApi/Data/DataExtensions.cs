using Microsoft.EntityFrameworkCore;
using SignApi.Repositories;

namespace SignApi.Data;

public static class DataExtensions
{
    public static async Task InitalizeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection service,
        IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("mssql");
        service.AddSqlServer<UserContext>(connString).AddScoped<IUsersRepository, EntityFrameWorkUsersRepository>();

        return service;
    }
}