# Building a Simple Command

To build a command for nsquared agents, create a .NET 10 class library with a class that
implements the [`IAgentCommand`](IAgentCommand.md) interface. Use the latest stable
`nsquared.agents.api` NuGet package.

> [The full source code for this example](https://github.com/nsquaredsolutions/agents/tree/main/Samples/SimpleCommand)

## Step-by-Step creating a simple nsquared agent Command

1. Start by creating a new C# class library project named SimpleCommand.

   ```bash
    dotnet new classlib --name SimpleCommand
   ```

   This will create a new folder named SimpleCommand containing C# project named SimpleCommand, and a code file named Class1.cs.
1. Rename the file `Class1.cs` to `Command.cs`
1. Rename the class in the code to `Command`

   ```cs
    namespace SimpleCommand;
    public class Command
    {
    }
   ```

1. In the `SimpleCommand.csproj` file set the framework and command file extension:

   ```xml
    <TargetFramework>net10.0</TargetFramework>
    <TargetExt>.Command</TargetExt>
   ```

1. Add the API package:

   ```sh
   dotnet add package nsquared.agents.api
   ```

1. In the `Command.cs` file add a `using` to import the `nsquared.agents` namespace

   ```cs
    using nsquared.agents;
   ```

1. In the `Command.cs` file implement the `IAgentCommand` interface in the Command class

   ```cs
    public class Command : IAgentCommand
   ```

1. Add the required methods to the `Command` class

   ```cs
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
   ```

1. Build the SimpleCommand project. It produces `SimpleCommand.Command` in the build output folder.
   This example has no additional dependencies and can be installed as a single file. If your
   command uses additional NuGet packages, include its assembly and required dependency DLLs in a
   flat `.zip` file with exactly one `.Command` file at the archive root. The running application
   accepts either the `.Command` file or ZIP from **Settings > Manage Commands**.

1. Run the nsquared agents application and open Settings, and then go to `Manage Commands`

   ![Manage Commands Menu in Settings](../images/ManageCommandsMenu.png)

1. In the Commands select Add

   ![Remove SimpleCommand from Commands](../images/AddNewCommand.png)

1. Find the SimpleCommand.Command file you have built.

   ![Remove SimpleCommand from Commands](../images/AddSimpleCommandCommand.png)

1. Invoke the SimpleCommand by using the keyword `simple` in your request 

![Doing a simple command](../images/DoingSimpleCommand.png)

> [The full source code for this example](https://github.com/nsquaredsolutions/agents/tree/main/Samples/SimpleCommand)

> [Building a Command with Settings](Building%20a%20Command%20with%20Settings.md)

> [Building a Skill](../Skills/Building%20a%20Simple%20Skill.md)