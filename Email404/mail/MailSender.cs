using System.Net;
using System.Net.Mail;

namespace Email404.mail;

public class MailSender(
    string userName = "1772775873@qq.com",
    string password = "jubcyxqveqcdebgj",
    string host = "smtp.qq.com",
    string senderMail = "1772775873@qq.com"
)
{
    public async Task SendMailAsync(MailAddress destination, string subject, string body)
    {
        var mail = new SmtpClient(host);
        mail.Credentials = new NetworkCredential(userName, password);
        var fromMail = new MailAddress(senderMail);
        var message = new MailMessage(fromMail, destination)
        {
            Subject = subject,
            Body = body
        };
        message.IsBodyHtml = true;
        await mail.SendMailAsync(message);
    }

    public async Task SendMailAsync(string destination, string subject, string body)
    {
        await SendMailAsync(new MailAddress(destination), subject, body);
    }

    public Task SendMailsAsync(IList<MailAddress> destinations, string subject, string body)
    {
        return Task.WhenAll(destinations.Select(x => SendMailAsync(x, subject, body)));
    }
}