// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using Email404.configuration;
using Email404.db;
using Email404.mail;
using Email404.template;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Email404;

internal static class Program
{
    private static readonly ILoggerFactory Factory = LoggerFactory.Create(x =>
    {
        //x.AddConsole();
        x.AddNLog();
    });

    private static readonly ILogger Logger = Factory.CreateLogger("Email404");

    public static async Task Main(string[] args)
    {
        Logger.Log(LogLevel.Information, "Program Start");
        var system = new ManageSystemContext();
        var configuration = LoadConfiguration();
        if (configuration.Mail.SenderMail == "" ||
            configuration.Mail.PassWord == "" ||
            configuration.Mail.UserName == "" ||
            configuration.Mail.Host == ""
           )
        {
            Logger.Log(LogLevel.Error, "请填写mail项下的参数");
            return;
        }

        var sender = new MailSender(
            configuration.Mail.UserName,
            configuration.Mail.PassWord,
            configuration.Mail.Host,
            configuration.Mail.SenderMail
        );
        foreach (var configurationReceiver in configuration.Receivers)
        {
            if (!configurationReceiver.Enabled)
            {
                Logger.Log(LogLevel.Debug, "{} is disabled and is skipped", configurationReceiver.Mail);
                continue;
            }

            Logger.Log(LogLevel.Information, "邮件接受者:{}", configurationReceiver.Mail);
            var text = "";
            foreach (var configurationReceiverGroup in configurationReceiver.Groups)
            {
                Logger.Log(LogLevel.Information, "正在处理:{}", configurationReceiverGroup);
                Group groupDefinition;
                try
                {
                    groupDefinition = configuration.Groups.First(x => x.Name == configurationReceiverGroup);
                }
                catch (InvalidOperationException)
                {
                    throw new FormatException($"不存在的group:{configurationReceiverGroup}");
                }
                var builder = MailTemplateBuilder.Title(groupDefinition.Name);
                var groupName = groupDefinition.Data.Name;
                var queryString = configuration.isDaily
                    ? system.GetStudentReportToday()
                    : system.GetStudentReportThisWeek();
                var members = UserRecordDatas(groupDefinition, queryString, groupName);
                foreach (var userRecordData in members) builder.UserData(userRecordData);

                text += builder.Build();
            }

            Logger.Log(LogLevel.Information, "正在发送邮件至:{}", configurationReceiver.Mail);
            await sender.SendMailAsync(configurationReceiver.Mail, configuration.isDaily ? "每日报告" : "每周报告", text);
        }

        Logger.Log(LogLevel.Information, "任务完成");
    }

    private static IEnumerable<UserRecordData> UserRecordDatas(Group groupDefinition, IQueryable<UserRecordData> queryString, string groupName)
    {
        var members = groupDefinition.Type switch
        {
            "custom" => from report in queryString.AsEnumerable()
                join member in groupDefinition.Data.Members on report.UserName equals member
                select report,
            "auto" => from report in queryString.AsEnumerable()
                where report.UserGroup == groupName
                select report,
            _ => throw new UnreachableException($"unknown type of group {groupDefinition.Type}")
        };
        return members;
    }

    private static Configuration LoadConfiguration()
    {
        if (!File.Exists("configuration.json"))
        {
            File.WriteAllText("configuration.json", JsonSerializer.Serialize(Configuration.Empty));
            Logger.Log(LogLevel.Error, "请填写配置文件:configuration.json");
            Environment.Exit(0);
        }

        return JsonSerializer.Deserialize<Configuration>(File.ReadAllText("configuration.json")) ??
               throw new InvalidDataException("文件格式错误或者不存在");
    }
}