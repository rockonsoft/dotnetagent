using System.Collections.Generic;
using System.Linq;
using models;
using Microsoft.EntityFrameworkCore;

namespace dal
{
  public interface IAgentService
  {
    Agent Add(string externalId);
    Agent Find(string externalId);
    Agent GetAppropriateAgent(IEnumerable<Action> uniqueActions);
    void AddJobToProcessingQueue(Job job);
  }
  public class AgentService : IAgentService
  {
    private readonly AgentContext _context;

    public AgentService(AgentContext context)
    {
      _context = context;
    }

    private List<JobQueue> CreateJobQueues()
    {
      JobQueue[] res = { new JobQueue { Purpose = QueuePurpose.Processing }, new JobQueue() { Purpose = QueuePurpose.Retry }, new JobQueue { Purpose = QueuePurpose.Succeeded }, new JobQueue { Purpose = QueuePurpose.Failed }, };
      return res.ToList();
    }
    public Agent Add(string externalId)
    {
      var agent = new Agent
      {
        ExternalId = externalId
      };

      agent.JobQueues.AddRange(CreateJobQueues());

      _context.Agents.Add(agent);
      _context.SaveChanges();
      return agent;
    }

    public Agent Find(string externalId)
    {
      return _context.Agents
          .Include(jq => jq.JobQueues)
          .Where(b => b.ExternalId == externalId)
          //   .OrderBy(b => b.Url)
          .ToList().First();
    }
    public Agent GetAppropriateAgent(IEnumerable<Action> uniqueActions)
    {
      return null;


    }

    public void AddJobToProcessingQueue(Job job)
    {

    }


    public IEnumerable<Job> Get()
    {
      return _context.Jobs
          .OrderBy(b => b.JobId)
          .ToList();
    }
  }
}
