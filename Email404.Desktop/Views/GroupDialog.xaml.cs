using Email404.configuration;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Email404.Desktop.Views;

public partial class GroupDialog : Window
{
    public ObservableGroup Group { get; private set; }
    
    public GroupDialog(Group? group = null)
    {
        InitializeComponent();
        Group = group != null ? new ObservableGroup(group) : new ObservableGroup();
        DataContext = Group;
    }
    
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Group.Name))
        {
            MessageBox.Show("请输入组名", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        
        DialogResult = true;
    }
} 