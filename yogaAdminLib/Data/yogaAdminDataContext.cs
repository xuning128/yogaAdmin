using Microsoft.EntityFrameworkCore;
using yogaAdminLib.Entities.yogaAdmin;

namespace yogaAdminLib.Data;

/// <summary>
/// admin's DataContext
/// </summary>
public class yogaAdminDataContext : DbContext
{
    public yogaAdminDataContext(DbContextOptions<yogaAdminDataContext> options) : base(options)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>()
                        .ToTable("teacher")
                        .HasKey(e => new { e.id });

         modelBuilder.Entity<YogaSchedule>()
                        .ToTable("yogaschedule")
                        .HasKey(e => new { e.rquid });

    }

    // Teachers info
    public DbSet<Teacher> Teachers { get; set; }

    //課表
    public DbSet<YogaSchedule> YogaSchedules { get; set; }




}