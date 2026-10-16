using nsquared.agents;
namespace SimpleCommand;

public class Command : IAgentCommand
{
    private readonly SimpleViewModel viewModel = new();
    public string Name => "SimpleCommand";

    public bool HasSettings => true;
    public AgentCommandType CommandType => AgentCommandType.KeywordLocal;

    public object? SettingsControl => new SettingsControl(viewModel);

    public Task<string?> Perform(string commandRequest, IAgentAnimations? animations)
    {
        if (commandRequest.Contains("simple", StringComparison.CurrentCultureIgnoreCase))
        {
            return Task.FromResult<string?>($"hello {viewModel.Name} I am doing a simple command!");
        }
        return Task.FromResult<string?>(null);
    }
}
