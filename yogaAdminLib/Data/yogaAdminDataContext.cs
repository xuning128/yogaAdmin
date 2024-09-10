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

        

    }

    // Teachers info
    public DbSet<Teacher> Teachers { get; set; }

   


}