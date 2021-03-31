using System;
using System.Collections.Generic;

namespace models
{

  public class Agent
  {
    private readonly List<JobQueue> _jobQueues = new List<JobQueue>();
    public List<JobQueue> JobQueues => _jobQueues;

    public int AgentId { get; set; }
    public string ExternalId { get; set; }

  }
}
