using Microsoft.Extensions.DependencyInjection;

namespace dal
{
  public static class IServiceCollectionExtension
  {
    public static IServiceCollection AddDalServices(this IServiceCollection services)
    {
      services.AddScoped<IAgentService, AgentService>();
      return services;
    }
  }
}