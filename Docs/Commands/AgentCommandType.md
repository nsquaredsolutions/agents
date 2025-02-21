# AgentCommandType

The `AgentCommandType` is used to specify the type of command that the agent can perform. This is used to determine the order in which the command is run.

| **Value** | **Description** |
|----|----|
|**KeywordLocal**|  A command that is triggered by a keyword that runs on the local computer, no network connection is required. These commands will be given a chance to run first.|
| **KeywordOnline** | A command that is triggered by a keyword that requires a network connection to run. These commands will be given a chance to run after the KeywordLocal commands. |
| **GeneralPurpose** | A general purpose command that is not triggered by a keyword and requires the most compute and/or network resources to run. These commands will be given a chance to run last.|

See also:

> [Instructions on building your own Command.](./Building%20a%20Simple%20Command)

> [IAgentCommand](./IAgentCommand)