namespace Email404.template;

public class MailTemplateBuilder
{
    private readonly List<UserRecordData> _data = [];
    private string _title = "";

    public static MailTemplateBuilder Title(string title)
    {
        return new MailTemplateBuilder { _title = title };
    }

    public void UserData(UserRecordData recordData)
    {
        _data.Add(recordData);
    }

    public string Build()
    {
        var text = "";
        text += MailTemplate.MailTitleTemplate.Replace("{title}", _title);

        return _data.Aggregate(text, (current, userRecordData) => current + MailTemplate.MailContentTemplateDaily
            .Replace("{userName}", userRecordData.UserName)
            .Replace("{time}", userRecordData.Hours.ToString() ?? "该成员未签到")
            .Replace("{today}", userRecordData.ContSummary ?? "该成员未提交简报")
            .Replace("{tomorrow}", userRecordData.ContPlan ?? "该成员未提交计划"));
    }
}