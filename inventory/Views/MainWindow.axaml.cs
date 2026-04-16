using Avalonia.Controls;
using inventory.ViewModels;

namespace inventory.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewmodel)
    {
        DataContext = viewmodel;
        InitializeComponent();
        viewmodel.SetScreen(this);
    }
}