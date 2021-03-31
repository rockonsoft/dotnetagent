using System.Collections.Generic;
using System.Linq;
using models;

namespace dal
{
  public interface IActionService
  {
    Action Find(string name);

  }
  public class ActionService : IActionService
  {
    private readonly AgentContext _context;

    public ActionService(AgentContext context)
    {
      _context = context;
    }

    public Action Find(string name)
    {
      return _context.Actions
          //   .Where(b => b.Url.Contains(term))
          //   .OrderBy(b => b.Url)
          .FirstOrDefault();
    }

    public static void Seed(AgentContext context)
    {

      var Http_GetOneAction = new Action() { ActionType = ActionType.Http_GetOne };
      Http_GetOneAction.Parameters.Add(new ActionParameter() { KeyName = "Url", ValueType = typeof(string).Name });
      Http_GetOneAction.Parameters.Add(new ActionParameter() { KeyName = "BearerToken", ValueType = typeof(string).Name });

    }
  }
}
