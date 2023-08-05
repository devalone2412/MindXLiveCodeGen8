using Microsoft.EntityFrameworkCore;
using MindXLiveCodeGen8.Domain.Entities;

namespace MindXLiveCodeGen8.Infrastructure;

public class OnlineResumeDbContext : DbContext
{
    public OnlineResumeDbContext(DbContextOptions<OnlineResumeDbContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Resume> Resumes { get; set; }
    public virtual DbSet<ResumeExperience> ResumeExperiences { get; set; }
    public virtual DbSet<ResumeEducation> ResumeEducations { get; set; }
    public virtual DbSet<ResumeSkill> ResumeSkills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");
            entity.Property(x => x.UserName).IsRequired();
            entity.Property(x => x.Password).IsRequired();
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.ToTable("Resume");
        });

        modelBuilder.Entity<ResumeExperience>(entity =>
        {
            entity.ToTable("ResumeExperience");
        });

        modelBuilder.Entity<ResumeEducation>(entity =>
        {
            entity.ToTable("ResumeEducation");
        });

        modelBuilder.Entity<ResumeSkill>(entity =>
        {
            entity.ToTable("ResumeSkill");
        });
    }
}