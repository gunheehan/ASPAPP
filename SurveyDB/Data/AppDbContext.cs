using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dictionaryConverter = new ValueConverter<Dictionary<string, object>, string>(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<Dictionary<string, object>>(v)
        );

        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Answer).HasConversion(dictionaryConverter);
            entity.HasIndex(e => e.RootId);
        });

        modelBuilder.Entity<SurveyForm>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.detail).HasConversion(dictionaryConverter);
        });

        modelBuilder.Entity<SurveyAnswer>()
            .HasIndex(e => e.RootId);
    }
}