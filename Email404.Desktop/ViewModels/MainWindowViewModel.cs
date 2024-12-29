using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Email404.configuration;
using Email404.Desktop.Services;
using Email404.Desktop.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace Email404.Desktop.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Receiver> receivers = [];

    [ObservableProperty]
    private ObservableCollection<Group> groups = [];

    [ObservableProperty]
    private string smtpServer = string.Empty;

    [ObservableProperty]
    private string senderMail = string.Empty;

    [ObservableProperty]
    private string username = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private bool isDaily;

    [ObservableProperty]
    private Receiver? selectedReceiver;

    [ObservableProperty]
    private Group? selectedGroup;

    [RelayCommand]
    private void AddReceiver()
    {
        var dialog = new ReceiverDialog(this);
        if (dialog.ShowDialog() == true)
        {
            Receivers.Add(dialog.ViewModel.ToReceiver());
        }
    }

    [RelayCommand]
    private void EditReceiver()
    {
        if (SelectedReceiver == null) return;
        
        var dialog = new ReceiverDialog(this,SelectedReceiver);
        dialog.ShowDialog();
    }

    [RelayCommand]
    private void DeleteReceiver()
    {
        if (SelectedReceiver == null) return;
        
        var result = MessageBox.Show(
            $"确定要删除接收者 {SelectedReceiver.Mail} 吗？", 
            "确认删除", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);
            
        if (result == MessageBoxResult.Yes)
        {
            Receivers.Remove(SelectedReceiver);
        }
    }

    [RelayCommand]
    private void AddGroup()
    {
        var dialog = new GroupDialog();
        if (dialog.ShowDialog() == true)
        {
            Groups.Add(dialog.Group.ToGroup());
        }
    }

    [RelayCommand]
    private void EditGroup()
    {
        if (SelectedGroup == null) return;
        
        var dialog = new GroupDialog(SelectedGroup);
        dialog.ShowDialog();
    }

    [RelayCommand]
    private void DeleteGroup()
    {
        if (SelectedGroup == null) return;
        
        var result = MessageBox.Show(
            $"确定要删除组 {SelectedGroup.Name} 吗？", 
            "确认删除", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);
            
        if (result == MessageBoxResult.Yes)
        {
            Groups.Remove(SelectedGroup);
        }
    }

    [RelayCommand]
    private void SaveConfiguration()
    {
        var config = new Configuration
        {
            Receivers = Receivers.ToList(),
            Groups = Groups.ToList(),
            Mail = new MailConfiguration
            {
                Host = SmtpServer,
                SenderMail = SenderMail,
                UserName = Username,
                PassWord = Password
            },
            isDaily = IsDaily
        };

        ConfigurationService.SaveConfiguration(config);
        MessageBox.Show("配置已保存", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    [RelayCommand]
    private void Cancel()
    {
        var result = MessageBox.Show(
            "确定要取消编辑吗？未保存的更改将丢失。", 
            "确认取消", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);
            
        if (result == MessageBoxResult.Yes)
        {
            LoadConfiguration();
        }
    }

    public MainWindowViewModel()
    {
        LoadConfiguration();
    }

    private void LoadConfiguration()
    {
        var config = ConfigurationService.LoadConfiguration();
        
        Receivers = new ObservableCollection<Receiver>(config.Receivers);
        Groups = new ObservableCollection<Group>(config.Groups);
        
        SmtpServer = config.Mail.Host;
        SenderMail = config.Mail.SenderMail;
        Username = config.Mail.UserName;
        Password = config.Mail.PassWord;
        
        IsDaily = config.isDaily;
    }
} 