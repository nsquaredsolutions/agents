# Building a Simple Skill

Skills are functions that an LLM host can invoke to do work through a command plugin. To build a
skill, create a .NET 10 class library with the latest stable `nsquared.agents.api` package and
implement [`IAgentSkill`](IAgentSkill.md). Provide the skill from a command implementing
`IAgentSkillProvider`.

## 1. Create a command project

```sh
dotnet new classlib --name GreetingCommand
cd GreetingCommand
dotnet add package nsquared.agents.api
```

Set these properties in `GreetingCommand.csproj`:

```xml
<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <TargetExt>.Command</TargetExt>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>enable</Nullable>
</PropertyGroup>
```

## 2. Implement the skill

Create `GreetingSkill.cs`. The schema is JSON Schema and must describe the JSON object accepted
by `ExecuteAsync`.

```csharp
using System.Text.Json;
using nsquared.agents;

namespace GreetingCommand;

public sealed class GreetingSkill : IAgentSkill
{
    public string FunctionName => "create_greeting";

    public string Description =>
        "Creates a short greeting for the supplied name. Use when the user asks for a greeting.";

    public string ParametersSchema =>
        """{"type":"object","properties":{"name":{"type":"string","description":"Person to greet"}},"required":["name"]}""";

    public Task<string> ExecuteAsync(string argumentsJson)
    {
        try
        {
            using var document = JsonDocument.Parse(argumentsJson);
            if (document.RootElement.ValueKind != JsonValueKind.Object ||
                !document.RootElement.TryGetProperty("name", out var nameElement) ||
                nameElement.ValueKind != JsonValueKind.String ||
                string.IsNullOrWhiteSpace(nameElement.GetString()))
            {
                return Task.FromResult("A non-empty name is required.");
            }

            return Task.FromResult($"Hello, {nameElement.GetString()}!");
        }
        catch (JsonException)
        {
            return Task.FromResult("Arguments must be valid JSON containing a non-empty string name.");
        }
    }
}
```

Keep the function name stable and use `snake_case`. Make the description specific so the model
can choose the skill appropriately. Validate input even though the parameter schema describes
the expected shape.

## 3. Provide the skill from a command

Create `GreetingCommand.cs`:

```csharp
using nsquared.agents;

namespace GreetingCommand;

public sealed class GreetingCommand : IAgentSkillProvider
{
    private readonly GreetingSkill greetingSkill = new();

    public string Name => "Greeting";
    public bool HasSettings => false;
    public AgentCommandType CommandType => AgentCommandType.GeneralPurpose;

    public IReadOnlyList<IAgentSkill> GetSkills() => [greetingSkill];

    public Task<string?> Perform(string commandRequest, IAgentAnimations? animations) =>
        Task.FromResult<string?>(null);
}
```

`GetSkills()` makes the skill available to the loaded `IAgentSkillHost`. If the command also
supports operation when no LLM host is available, implement its normal `Perform` fallback as
appropriate. An LLM host must override `ReceiveSkillsFromProviders` and include the received
skills as function/tool definitions in its model request.

Build the project to produce `GreetingCommand.Command`. This example uses only the API package
and can be installed as a single file. If your command uses additional NuGet packages, include
the command assembly and required dependency DLLs in a flat `.zip` file, with exactly one
`.Command` file at the archive root. In the running application, add the `.Command` file or ZIP
from **Settings > Manage Commands**.

## Optional trigger and prompt guidance

For deterministic intent matching or argument extraction, also implement `IAgentSkillTrigger`.
Its `ShouldHandle` method receives the current conversation context; `BuildArgumentsJson` creates
the JSON passed to `ExecuteAsync`. Higher `Priority` values win when triggers overlap. To add
skill-specific guidance for the LLM, implement `IAgentSkillPromptInstruction` and provide
`PromptInstruction`. These are optional extensions; basic model-selected tool calls need only
`IAgentSkill`.
