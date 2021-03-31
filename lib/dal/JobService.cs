using System.Collections.Generic;
using System.Linq;
using models;

namespace dal
{
  public interface IJobService
  {
    Job Add(Flow flow, IEnumerable<JobParameter> initialParameters);
    IEnumerable<Job> Get();
  }
  public class JobService
  {
    private readonly AgentContext _context;

    public JobService(AgentContext context)
    {
      _context = context;
    }

    public Job Add(Flow flow, IEnumerable<JobParameter> initialParameters)
    {
      var job = new Job { };
      _context.Jobs.Add(job);
      _context.SaveChanges();
      return job;
    }

    // public IEnumerable<Blog> Find(string term)
    // {
    //   return _context.Blogs
    //       .Where(b => b.Url.Contains(term))
    //       .OrderBy(b => b.Url)
    //       .ToList();
    // }

    public IEnumerable<Job> Get()
    {
      return _context.Jobs
          .OrderBy(b => b.JobId)
          .ToList();
    }
  }
}
