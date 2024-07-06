namespace Email404.mail;

public class MailTask(List<string> members, List<string> receivers, string title)
{
    public List<string> Members { get; } = members;
    public List<string> Receivers { get; } = receivers;
    public string Title { get; } = title;
}