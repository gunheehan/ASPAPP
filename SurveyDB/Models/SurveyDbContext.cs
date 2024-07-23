using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SurveyDB.Models;

public partial class SurveyDbContext : DbContext
{
    public SurveyDbContext()
    {
    }

    public SurveyDbContext(DbContextOptions<SurveyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

    public virtual DbSet<SurveyForm> SurveyForms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=SurveyDB;user=root;password=salin2017", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("survey_answer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Answers)
                .HasColumnType("json")
                .HasColumnName("answers");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.FormKey)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("form_key");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<SurveyForm>(entity =>
        {
            entity.HasKey(e => e.FormKey).HasName("PRIMARY");

            entity.ToTable("survey_form");

            entity.Property(e => e.FormKey)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("form_key");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Questions)
                .HasColumnType("json")
                .HasColumnName("questions");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
