using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

using dal;
using models;

namespace libtests
{
  public class SharedDatabaseFixture : IDisposable
  {
    private static readonly object _lock = new object();
    private static bool _databaseInitialized;

    private readonly DbConnection _connection;

    public DbConnection Connection { get; }


    public SharedDatabaseFixture()
    {
      Connection = new SqliteConnection("Filename=:memory:");
      //   Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=EFTestSample;ConnectRetryCount=0");
      Connection.Open();

      Seed();

    }

    // private static DbConnection CreateInMemoryDatabase()
    // {
    //   var connection = new SqliteConnection("Filename=:memory:");

    //   connection.Open();

    //   return connection;
    // }

    // public DbConnection Connection { get; }

    public AgentContext CreateContext(DbTransaction transaction = null)
    {
      var context = new AgentContext(new DbContextOptionsBuilder<AgentContext>().UseSqlite(Connection).Options);

      if (transaction != null)
      {
        context.Database.UseTransaction(transaction);
      }

      return context;
    }

    private void Seed()
    {
      lock (_lock)
      {
        if (!_databaseInitialized)
        {
          using (var context = CreateContext())
          {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var job1 = new Job();
            var job2 = new Job();

            context.AddRange(job1, job2);

            var agent1 = new Agent();
            agent1.ExternalId = TestConstants.AgentId1;

            var jobQueue1 = new JobQueue();

            agent1.JobQueues.Add(jobQueue1);

            var agent2 = new Agent();
            agent2.ExternalId = TestConstants.AgentId2;
            var jobQueue2 = new JobQueue();

            agent2.JobQueues.Add(jobQueue2);


            context.AddRange(agent1, agent2);


            ActionService.Seed(context);

            context.SaveChanges();
          }

          _databaseInitialized = true;
        }
      }
    }

    public void Dispose() => Connection.Dispose();
  }
}
