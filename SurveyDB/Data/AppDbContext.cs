using Azure.ResourceManager.MySql.Models;
using Microsoft.EntityFrameworkCore;

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

    public void ConfigureDynamicTable(Dictionary<string, Type> dynamicColumns, string tableName)
    {
        _dynamicColumns = dynamicColumns;
        _tableName = tableName;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (_dynamicColumns != null && !string.IsNullOrEmpty(_tableName))
        {
            var entityBuilder = modelBuilder.Entity<DynamicTable>();

            entityBuilder.ToTable(_tableName);
            entityBuilder.HasKey(e => e.Id);

            foreach (var column in _dynamicColumns)
            {
                var propertyBuilder = entityBuilder.Property(column.Value, column.Key);
                if (column.Value == typeof(string))
                {
                    propertyBuilder.IsRequired(false);
                }
            }
        }
    }
    
}