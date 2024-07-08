// See https://aka.ms/new-console-template for more information

using System.Net.Mail;
using System.Text.Json;
using Email404.db;
using Email404.mail;
using Email404.template;

namespace Email404;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var system = new ManageSystemContext();
        var configuration = LoadConfiguration();
        var sender = new MailSender();
        foreach (var configurationReceiver in configuration.Receivers)
        {
            var text = "";
            foreach (var configurationReceiverGroup in configurationReceiver.Groups)
            {
                var groupDefinition = configuration.Groups.First(x => x.Name == configurationReceiverGroup);
                var builder = MailTemplateBuilder.Title(groupDefinition.Name);
                var members = groupDefinition.Type switch
                {
                    "custom" => from report in system.GetStudentReportToday().AsEnumerable()
                        join member in groupDefinition.Data.Members on report.UserName equals member
                        select report,
                    "auto" => from report in system.GetStudentReportToday().AsEnumerable()
                        where report.UserGroup == groupDefinition.Data.Name 
                        select report,
                    _ => throw new ArgumentOutOfRangeException()
                };
                foreach (var userRecordData in members)
                {
                    builder.UserData(userRecordData);
                }

                text += builder.Build();

            }

            await sender.SendMailAsync(configurationReceiver.Mail,"报告", text);
        }
        
        
        
        
    }

    private static Configuration LoadConfiguration()
    {
        if (!File.Exists("configuration.json"))
            File.WriteAllText("configuration.json", JsonSerializer.Serialize(Configuration.Empty));
        return JsonSerializer.Deserialize<Configuration>(File.ReadAllText("configuration.json")) ??
               throw new InvalidDataException("文件格式错误或者不存在");
    }
}