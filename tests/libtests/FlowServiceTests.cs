using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using dal;
using models;

namespace libtests
{
  public class FlowServiceTests : IClassFixture<SharedDatabaseFixture>
  {
    public FlowServiceTests(SharedDatabaseFixture fixture) => Fixture = fixture;
    public SharedDatabaseFixture Fixture { get; }

    [Fact]
    public void When_adding_a_flow_the_steps_gets_added_too()
    {
      using (var context = Fixture.CreateContext())
      {
        var sut = new FlowService(context);
        var newFlow = new Flow() { Name = TestConstants.FlowName1 };
        newFlow.AddStepInOrder(new Step() { Name = "Step1" });
        newFlow.AddStepInOrder(new Step() { Name = "Step2" });
        newFlow.AddStepInOrder(new Step() { Name = "Step3" });
        newFlow.AddStepInOrder(new Step() { Name = "Step4" });

        sut.Add(newFlow);

        var flow = sut.Find(TestConstants.FlowName1);
        Assert.Equal(TestConstants.FlowName1, flow.Name);
        Assert.Equal(4, flow.Steps.Count);
        // Todo  - verify this independently
        Assert.Equal(1, flow.Steps[0].Order);
        Assert.Equal(2, flow.Steps[1].Order);
        Assert.Equal(3, flow.Steps[2].Order);
        Assert.Equal(4, flow.Steps[3].Order);
      }
    }
    // [Fact]
    // public void When_Agent_is_searched_by_externalId_the_jobqueues_are_returned_also()
    // {
    //   using (var context = Fixture.CreateContext())
    //   {
    //     var sut = new AgentService(context);

    //     var agents = sut.Find(TestConstants.AgentId2);

    //     Assert.Equal(TestConstants.AgentId2, agents.ExternalId);
    //     Assert.Equal(1, agents.JobQueues.Count);
    //   }
    // }
  }
}
