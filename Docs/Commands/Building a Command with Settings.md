# Building a Command with Settings

This document assumes you have read and understood [Building a Simple Command](Building%20a%20Simple%20Command.md).

Your custom command may need to present options to the customer of your command. This is done by extending the Settings of nsquared agents with a dialog for the command you are building.

The user interface will need to be defined as an [Avalonia UserControl](https://docs.avaloniaui.net/docs/reference/controls/usercontrol).

## Step-by-Step creating an nsquared agent Command with Settings

This guide starts with the [Simple Command built in the guide here](Building%20a%20Simple%20Command.md).

1. Add the Avalonia UI package to the project. In terminal, in the same folder and the SimpleCommand.csproj file.

   ```shell
   dotnet add package Avalonia --version 11.2.3
   ```

2. Add the Avalonia.ReactiveUI package to the project. In terminal, in the same folder and the SimpleCommand.csproj file.

   ```shell
   dotnet add package Avalonia.ReactiveUI --version 11.2.3
   ```

3. Create a ViewModel class to hold the settings values. In terminal, in the same folder and the SimpleCommand.csproj file.

   ```shell
   dotnet new class -n SimpleViewModel
   ```

4. Open the `SimpleViewModel.cs` file and edit it to contain a property that can be set.

    ```cs
    using ReactiveUI;

    namespace SimpleCommand;

    public class SimpleViewModel : ReactiveObject
    {
        private static string name = string.Empty;

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
    }
    ```

5. To create the Avalonia UserControl you will use the Avalonia Templates. If you do not have them installed locally you can do this from Terminal

   ```shell
   dotnet new install Avalonia.Templates
   ```

6. Create a new Settings UserControl. In terminal, in the same folder and the SimpleCommand.csproj file.

   ```shell
   dotnet new avalonia.usercontrol -n Settings
   ```

    This will create two files in the project folder `Settings.axaml` and `Settings.axaml.cs`

7. 

