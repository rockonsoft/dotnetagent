
using System;
using System.Collections.Generic;
using System.Linq;
using models;

namespace dal
{

  public class Orchestrator
  {
    private IFlowService flowService;
    private IActionService actionService;
    private IJobService jobService;
    private IAgentService agentService;
    public Orchestrator(IFlowService flowService, IActionService actionService, IJobService jobService, IAgentService agentService)
    {
      this.flowService = flowService;
      this.actionService = actionService;
      this.jobService = jobService;
      this.agentService = agentService;
    }


    private List<JobQueueingError> CheckInitialParams(IEnumerable<ActionParameter> initialParams, Dictionary<string, string> parameters)
    {
      throw new System.NotImplementedException();
    }

    private void LogErros(List<JobQueueingError> paramErros)
    {
      throw new NotImplementedException();
    }


    private IEnumerable<JobParameter> CreateInitialParameters(IEnumerable<ActionParameter> initialParams, Dictionary<string, string> parameters)
    {
      return null;

    }
    public Job Enqueue(string flowName, Dictionary<string, string> parameters)
    {
      //find the flow with the name
      var flow = this.flowService.Find(flowName);

      //get all the parameter required by the first step
      var initialParams = this.flowService.GetInitialActionParameters(flow);

      //check that each required initial param is supplied
      var paramErros = this.CheckInitialParams(initialParams, parameters);
      if (0 == paramErros.Count)
      {
        LogErros(paramErros);
        return null;
      }
      // get a unique list of actions
      var uniqueActions = this.flowService.GetUniqueActionsForFlow(flow);


      //find an appropriate agent
      var agent = this.agentService.GetAppropriateAgent(uniqueActions);

      // create the job
      var job = this.jobService.Add(flow, this.CreateInitialParameters(initialParams, parameters));

      //stick it on the agent's processing queue
      this.agentService.AddJobToProcessingQueue(job);
      return job;
    }

  }
}