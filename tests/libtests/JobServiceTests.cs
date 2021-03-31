using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using dal;

namespace libtests
{
  public class JobServiceTests : IClassFixture<SharedDatabaseFixture>
  {
    public JobServiceTests(SharedDatabaseFixture fixture) => Fixture = fixture;
    public SharedDatabaseFixture Fixture { get; }

    [Fact]
    public void Can_get_jobs()
    {
      using (var context = Fixture.CreateContext())
      {
        var sut = new JobService(context);

        var jobs = sut.Get().ToList();

        Assert.Equal(2, jobs.Count);
        // Assert.Equal("ItemOne", items[0].Name);
        // Assert.Equal("ItemThree", items[1].Name);
        // Assert.Equal("ItemTwo", items[2].Name);
      }
    }
  }
}
