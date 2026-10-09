# AgentCommandType

`AgentCommandType` sets the routing order in which the application gives commands an opportunity
to handle a request. The default `IAgentCommand.CommandType` is `GeneralPurpose`.

| Value | Description |
|---|---|
| `KeywordLocal` | Keyword-triggered command that runs locally; tried first. |
| `KeywordOnline` | Keyword-triggered command that needs a network connection; tried after local keyword commands. |
| `GeneralPurpose` | General-purpose command; tried after keyword commands. |

See also:

> [Instructions on building your own command](Building%20a%20Simple%20Command.md).

> [IAgentCommand](IAgentCommand.md).