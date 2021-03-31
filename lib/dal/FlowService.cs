using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using models;

namespace dal
{
  public interface IFlowService
  {
    void Add(Flow flow);
    Flow Find(string name);
    IEnumerable<ActionParameter> GetInitialActionParameters(Flow flow);
    IEnumerable<Action> GetUniqueActionsForFlow(Flow flow);
  }



  public class FlowService : IFlowService
  {
    private readonly AgentContext _context;

    public FlowService(AgentContext context)
    {
      _context = context;
    }

    public void Add(Flow flow)
    {
      _context.Flows.Add(flow);
      _context.SaveChanges();
    }

    public Flow Find(string name)
    {
      return _context.Flows
          .Include(f => f.Steps)
          .Where(b => b.Name == name)
          // .OrderBy(b => b.Url)
          .FirstOrDefault();
    }

    public IEnumerable<Action> GetUniqueActionsForFlow(Flow flow)
    {
      return null;
    }
    public IEnumerable<ActionParameter> GetInitialActionParameters(Flow flow)
    {
      return null;
    }

    // public IEnumerable<Job> Get()
    // {
    //   return _context.Jobs
    //       .OrderBy(b => b.JobId)
    //       .ToList();
    // }
  }
}
