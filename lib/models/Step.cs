using System;
using System.Collections.Generic;

namespace models
{
  public class Step
  {
    public int StepId { get; set; }

    public string Name { get; set; }

    public int Order { get; set; }
    public Flow Flow { get; set; }

    public Action Action { get; set; }

  }

}
