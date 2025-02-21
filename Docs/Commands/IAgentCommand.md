# The IAgentCommand interface

A Command consists of the following files and methods.

| Field          | Type |  Description   |
|----------------|------|----------------|
| Name          |   `String` | The name of the command |
| CommandType   | [`AgentCommandType`](AgentCommandType.md) | The type of command that the agent can perform. This is used to determine the order in which the command is run.
| HasSettings  | `Bool` | True if this command has settings that the user can configure. If True then `SettingsControl` must return an Avalonia UserControl. Default is false.
| SettingsControl | `object?` | The user control that the user can use to configure the settings. This will need to be an Avalonia UserControl with a max width of 260 and a max height of 210.

| **Method** | **Description**  | **Parameters** | **Returns** |
|----------------|----------|----------------|----------------|
| **Perform** | Perform the command if the command request provides the necessary information or keywords to carry out the command.  |  `string` **commandRequest**  the request made by the human to the agent.  | `string?` The response the agent should provide|
||| `IAgentAnimations?` **animations** an instance of an IAgentAnimations that the command can use to trigger animations in the active character. ||

See also:

> [Instructions on building your own Command.](./Building%20a%20Simple%20Command)

> [AgentCommandType](./AgentCommandType)