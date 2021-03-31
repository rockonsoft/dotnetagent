using System;
using System.Collections.Generic;

namespace models
{
  public enum ActionType
  {
    None,
    Http_Post,
    Http_Put,
    Http_GetOne,
    Http_GetMany,
    Http_Delete,

  }
  ///
  /// /* Actions are system maintained capacities - not to be added by users */
  public class Action
  {
    private readonly List<ActionParameter> _parameters = new List<ActionParameter>();
    public List<ActionParameter> Parameters => _parameters;

    public int ActionId { get; set; }
    public ActionType ActionType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

  }

}
