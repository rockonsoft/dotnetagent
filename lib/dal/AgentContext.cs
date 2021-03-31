using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using models;

namespace dal
{
  public class AgentContext : DbContext
  {
    public AgentContext(DbContextOptions<AgentContext> options)
    : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseNpgsql("Host=localhost;Database=dotnet;Username=postgres;Password=changeme");

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Job> Jobs { get; set; }

    // public DbSet<JobProcessingError> JobProcessingErrors { get; set; }

    // public DbSet<JobQueue> JobQueues { get; set; }

    // public DbSet<AuditLog> AuditLogs { get; set; }

    public DbSet<Action> Actions { get; set; }
    public DbSet<Flow> Flows { get; set; }
    public DbSet<Step> Steps { get; set; }

  }

}
