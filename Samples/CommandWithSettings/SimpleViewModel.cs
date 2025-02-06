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
