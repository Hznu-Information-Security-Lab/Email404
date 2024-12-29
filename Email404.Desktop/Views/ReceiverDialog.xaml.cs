using Email404.configuration;
using System.Windows;
using Email404.Desktop.ViewModels;

namespace Email404.Desktop.Views;

public partial class ReceiverDialog : Window
{
    public ReceiverViewModel ViewModel { get; } 
    public ReceiverDialog(MainWindowViewModel viewModel,Receiver receiver = null)
    {
        InitializeComponent();
        ViewModel = new ReceiverViewModel(viewModel, receiver == null ? new ObservableReceiver() : new ObservableReceiver(receiver));
        DataContext = ViewModel;
        ViewModel.ConfirmEvent += () =>
        {
            DialogResult = true;
        };

    }
    
} 