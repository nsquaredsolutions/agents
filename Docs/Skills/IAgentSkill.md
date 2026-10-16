# The skill API

The skill contracts are included in the `nsquared.agents.api` NuGet package. Add that package to
your command project and use the `nsquared.agents` namespace.

## `IAgentSkill`

| Member | Type | Description |
|---|---|---|
| `FunctionName` | `string` | Tool/function name given to the LLM. Use a stable `snake_case` name. |
| `Description` | `string` | Concise, action-oriented explanation of what the skill does and when to use it. |
| `ParametersSchema` | `string` | JSON Schema for the function's arguments. For no arguments use `{"type":"object","properties":{}}`. |
| `ExecuteAsync` | `Task<string>` | Executes the skill with JSON arguments and returns a plain-text result for the LLM. |

## Supplying and consuming skills

An `IAgentSkillProvider` is a command that supplies skills. The API provides a default empty
implementation of `GetSkills()`; override it to return the skills your command owns:

```csharp
public interface IAgentSkillProvider : IAgentCommand
{
    IReadOnlyList<IAgentSkill> GetSkills() => [];
}
```

An `IAgentSkillHost` is an LLM command that consumes supplied skills:

```csharp
public interface IAgentSkillHost : IAgentCommand
{
    void ReceiveSkillsFromProviders(IReadOnlyList<IAgentSkill> skills) { }
}
```

The application calls `ReceiveSkillsFromProviders` after loading skill-provider commands.
The host should retain the skills and send their function names, descriptions, and parameter
schemas to the model as tool definitions. The method's default implementation does nothing, so a
host must override it to use skills.

An LLM host normally builds a tool definition for each received skill using its
`FunctionName`, `Description`, and `ParametersSchema`. When the model requests a tool call, the
host passes the call's argument JSON to that skill's `ExecuteAsync` method and returns the
result to the model. A command that only provides skills does not need to implement a model
client.

## Optional skill metadata

`IAgentSkillTrigger` lets a skill declare when it should be selected deterministically rather than
waiting for the model to choose a tool. It provides:

- `Priority`: larger values win when multiple skills match the same prompt.
- `ShouldHandle(AgentSkillPromptContext)`: whether this skill claims the current conversation.
- `BuildArgumentsJson(AgentSkillPromptContext)`: arguments passed to `ExecuteAsync`.

The context exposes messages in chronological order, the current user prompt, and the preceding
user prompt and assistant response. `AgentSkillPromptMatcher.ContainsAny` provides a shared,
case-insensitive phrase matcher.

`IAgentSkillPromptInstruction` is another optional interface. Its `PromptInstruction` text is
appended to the host model's system prompt when the skill is loaded.

For time-sensitive domains such as weather, schedules, news, or prices, provide a low-priority
guard trigger for domain requests that no data skill handles. The model should not fill gaps in
live data from its training knowledge; use `int.MinValue` for the guard priority so matching data
skills take precedence.

The skill types live in the `nsquared.agents` namespace:

```csharp
public interface IAgentSkill
{
    string FunctionName { get; }
    string Description { get; }
    string ParametersSchema { get; }
    Task<string> ExecuteAsync(string argumentsJson);
}

public interface IAgentSkillPromptInstruction
{
    string PromptInstruction { get; }
}

public interface IAgentSkillTrigger : IAgentSkill
{
    int Priority { get; }
    bool ShouldHandle(AgentSkillPromptContext context);
    string BuildArgumentsJson(AgentSkillPromptContext context);
}
```

`AgentSkillPromptContext` contains `Messages` in chronological order, `CurrentUserPrompt`,
`PreviousUserPrompt`, and `PreviousAssistantResponse`. Each item in `Messages` has a `Role`
(typically `"user"` or `"assistant"`) and nullable `Content`. The API also provides
`AgentSkillPromptMatcher.ContainsAny(request, phrases...)` for case-insensitive phrase matching.
