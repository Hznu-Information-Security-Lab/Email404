﻿using System.Globalization;

namespace Email404.template;

public class MailTemplateBuilder
{
    private readonly List<UserRecordData> _data = [];
    private string _title = "";
    public bool IsDaily { get; set; }= false;
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

        return _data.Aggregate(text, (current, userRecordData) => current + (
                IsDaily ? 
                MailTemplate.MailContentTemplateDaily : 
                MailTemplate.MailContentTemplateWeekly )
            .Replace("{userName}", userRecordData.UserName)
            .Replace("{time}",
                Math.Round((double)(userRecordData.Hours ?? 0), 2).ToString(CultureInfo.CurrentCulture) ?? "该成员未签到")
            .Replace("{today}", userRecordData.ContSummary ?? "该成员未提交简报")
            .Replace("{tomorrow}", userRecordData.ContPlan ?? "该成员未提交计划"));
    }
}