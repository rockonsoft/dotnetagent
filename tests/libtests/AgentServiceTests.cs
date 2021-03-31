using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using dal;

namespace libtests
{
  public class AgentServiceTests : IClassFixture<SharedDatabaseFixture>
  {
    public AgentServiceTests(SharedDatabaseFixture fixture) => Fixture = fixture;
    public SharedDatabaseFixture Fixture { get; }

    [Fact]
    public void When_Agent_is_added_all_jobqueues_are_created()
    {
      using (var context = Fixture.CreateContext())
      {
        var sut = new AgentService(context);

        sut.Add(TestConstants.AgentId3);

        var agent = sut.Find(TestConstants.AgentId3);
        Assert.Equal(TestConstants.AgentId3, agent.ExternalId);
        Assert.Equal(4, agent.JobQueues.Count);
      }
    }
    [Fact]
    public void When_Agent_is_searched_by_externalId_the_jobqueues_are_returned_also()
    {
      using (var context = Fixture.CreateContext())
      {
        var sut = new AgentService(context);

        var agents = sut.Find(TestConstants.AgentId2);

        Assert.Equal(TestConstants.AgentId2, agents.ExternalId);
        Assert.Equal(1, agents.JobQueues.Count);
      }
    }

    [Fact]
    public void GetAppropriateAgent_returns_null_when_not_all_actions_are_executable()
    {
      Assert.True(false);
    }

  }
}
