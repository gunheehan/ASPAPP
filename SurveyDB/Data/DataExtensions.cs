using SurveyDB.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SurveyDB.Data;

public static class DataExtensions
{
    public static void InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRespositories(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("AppDbContext");
        services.AddSqlServer<AppDbContext>(connString)
            .AddScoped<ISurveyRepository, SurveyRepository>();

        return services;
    }
}