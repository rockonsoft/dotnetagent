using System;
using System.Collections.Generic;
using System.Linq;


namespace models
{
  public class Flow
  {
    private readonly List<Step> _steps = new List<Step>();
    public List<Step> Steps => _steps;

    public int FlowId { get; set; }
    public string Name { get; set; }


    public Step AddStepInOrder(Step step)
    {
      var foundStep = _steps.FirstOrDefault(t => t.Name == step.Name);

      if (foundStep == null)
      {
        _steps.Add(step);
      }

      step.Order = _steps.Count;

      return step;

    }

  }

}
