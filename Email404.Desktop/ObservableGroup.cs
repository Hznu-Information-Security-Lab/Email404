using CommunityToolkit.Mvvm.ComponentModel;
using Email404.configuration;

namespace Email404.Desktop;

public partial class ObservableGroup: ObservableObject
{
    [ObservableProperty] private string _name = "";
    [ObservableProperty] private string _type = "custom";
    public string[] Typies { get; set; }= ["custom", "auto"];
    [ObservableProperty] private Data _data = new Data();
    // public Data Data { get; set; }
    public ObservableGroup(Group group)
    {
        Name = group.Name;
        Type = group.Type;
        Data = group.Data;
    }
    
    public ObservableGroup(){}

    public Group ToGroup()
    {
        return new Group
        {
            Name = this.Name,
            Type = this.Type,
            Data = this.Data
        };
    }

    
}