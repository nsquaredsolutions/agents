using nsquared.agents;
namespace SimpleCommand;

public class Command : IAgentCommand
{
    public string Name => "SimpleCommand";

    public bool HasSettings => false;
    public AgentCommandType CommandType => AgentCommandType.KeywordLocal;

    public Task<string?> Perform(string commandRequest, IAgentAnimations? animations)
    {
        if (commandRequest.Contains("simple", StringComparison.CurrentCultureIgnoreCase))
        {
            animations?.Animate("Announce");
            return Task.FromResult<string?>("I am doing a simple command!");
        }
        return Task.FromResult<string?>(null);
    }
}
