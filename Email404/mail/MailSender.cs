using System.Net;
using System.Net.Mail;

namespace Email404.mail;

public class MailSender(
    string userName = "1772775873@qq.com",
    string password="jubcyxqveqcdebgj"
    )
{
    public async Task SendMailAsync(MailAddress destination,string subject,string body)
    {
        var mail = new SmtpClient("smtp.qq.com");
        mail.Credentials = new NetworkCredential(userName, password);
        var fromMail = new MailAddress("1772775873@qq.com");
        var toMail = new MailAddress("mail@myot.site");
        var message = new MailMessage(fromMail, toMail)
        {
            Subject = subject,
            Body = body
        };
        await mail.SendMailAsync(message);

    }
    
    public Task SendMailsAsync(IList<MailAddress> destinations,string subject,string body) => 
        Task.WhenAll(destinations.Select(x => SendMailAsync(x, subject, body)));
    
}