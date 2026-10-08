# The `IAgentCommand` interface

Implement `nsquared.agents.IAgentCommand` from the `nsquared.agents.api` NuGet package to add a
command to the application.

| Member | Type | Description |
|---|---|---|
| `Name` | `string` | Command name. Required. |
| `HasSettings` | `bool` | Whether the command exposes user-configurable settings. Required. |
| `SettingsControl` | `object?` | Avalonia control used to configure the command. Defaults to `null`. |
| `CommandType` | [`AgentCommandType`](AgentCommandType.md) | Routing priority. Defaults to `GeneralPurpose`. |
| `Perform` | `Task<string?>` | Receives the request and optional animation API; return a response when handled, or `null` to let another command handle it. |

`Perform` receives the original request as `string commandRequest` and an
`IAgentAnimations? animations` reference. The animation API can animate the active character,
display a user-facing notification, write a diagnostic note, and provide the active character's
name and personality.

`SettingsControl` should return an Avalonia `UserControl` when `HasSettings` is `true`. The
`SettingsControl` and `CommandType` members have default interface implementations, so a command
can omit them when it does not need custom settings or routing.

Commands can also provide LLM-callable skills by implementing
[`IAgentSkillProvider`](../Skills/IAgentSkill.md). An LLM command that consumes skills implements
`IAgentSkillHost`; see [Building a simple skill](../Skills/Building%20a%20Simple%20Skill.md).

See also:

> [Instructions on building your own command](Building%20a%20Simple%20Command.md).

> [AgentCommandType](AgentCommandType.md).