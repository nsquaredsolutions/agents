using Avalonia.Controls;

namespace SimpleCommand;

public partial class SettingsControl : UserControl
{
    public SettingsControl()
    {
        InitializeComponent();
    }

    public SettingsControl(SimpleViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}