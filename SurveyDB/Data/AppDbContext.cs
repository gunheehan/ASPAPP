using System.Text.Json;
using Azure.ResourceManager.MySql.Models;
using Microsoft.EntityFrameworkCore;
using SurveyDB.Entities;

namespace SurveyDB.Data;

public class DynamicTable
{
    public int Id { get; set; }
    // 기본 컬럼 정의 (필요에 따라 추가)
}

public class DefaultTable
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum ColumeDataType
{
    String,
    Int,
    Bool
}
public class AppDbContext : DbContext
{
    private Dictionary<string, Type> _dynamicColumns;
    private string _tableName;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SurveyForm> SurveyForms => Set<SurveyForm>();
    public DbSet<SurveyAnswer> SurveyAnswers => Set<SurveyAnswer>();

    // public void ConfigureDynamicTable(Dictionary<string, Type> dynamicColumns, string tableName)
    // {
    //     _dynamicColumns = dynamicColumns;
    //     _tableName = tableName;
    // }
    //
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //
    //     if (_dynamicColumns != null && !string.IsNullOrEmpty(_tableName))
    //     {
    //         var entityBuilder = modelBuilder.Entity<DynamicTable>();
    //
    //         entityBuilder.ToTable(_tableName);
    //         entityBuilder.HasKey(e => e.Id);
    //
    //         foreach (var column in _dynamicColumns)
    //         {
    //             var propertyBuilder = entityBuilder.Property(column.Value, column.Key);
    //             if (column.Value == typeof(string))
    //             {
    //                 propertyBuilder.IsRequired(false);
    //             }
    //         }
    //     }
    // }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.ToTable("Survey_Answer");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .HasMaxLength(30);

            entity.Property(e => e.UserId)
                .HasMaxLength(20);

            entity.Property(e => e.Answer)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                    v => JsonSerializer.Deserialize<Dictionary<string, object>>(v, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
                );
        });
    }
    
}