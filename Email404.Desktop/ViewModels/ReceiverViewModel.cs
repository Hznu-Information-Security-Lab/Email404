using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Email404.configuration;

namespace Email404.Desktop.ViewModels;

public partial class ReceiverViewModel(MainWindowViewModel vm, ObservableReceiver receiver) : ObservableObject
{
    private readonly MainWindowViewModel _vm = vm;

    [ObservableProperty] private ObservableReceiver _receiver = receiver;
    public ObservableCollection<Group> Available => vm.Groups;
    [ObservableProperty] private Group _selectedAvailableGroup = null;
    [ObservableProperty] private string _selectedGroup;

    public delegate void ConfirmDelegate();

    public event ConfirmDelegate? ConfirmEvent; 
    [RelayCommand]
    private void ConfirmOk()
    {
        ConfirmEvent?.Invoke();

    }
    [RelayCommand]
    private void AddGroup()
    {
        if (SelectedAvailableGroup == null)
        {
            MessageBox.Show("请输入组名", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        Receiver.Groups.Add(SelectedAvailableGroup.Name);
    }
    [RelayCommand]
    private void RemoveGroup()
    {
        Receiver.Groups.Remove(SelectedGroup);
        
    }
    public Receiver ToReceiver()
    {
        
        return Receiver.ToReceiver();
    }
    
}