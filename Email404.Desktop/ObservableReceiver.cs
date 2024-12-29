using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Email404.configuration;

namespace Email404.Desktop;

public partial class ObservableReceiver: ObservableObject
{
    public ObservableReceiver(Receiver receiver)
    {
        _enabled = receiver.Enabled;
        _mail = receiver.Mail;
        _groups = new ObservableCollection<string>(receiver.Groups);
    }

    public Receiver ToReceiver()
    {
        return new Receiver
        {
            Enabled = true,
            Groups = _groups.ToList(),
            Mail = Mail
        };
    }
    
    public ObservableReceiver(){}
    [ObservableProperty] private string _mail = "";

    [ObservableProperty] private bool _enabled = true;
    
    [ObservableProperty] private ObservableCollection<string> _groups = [];
}