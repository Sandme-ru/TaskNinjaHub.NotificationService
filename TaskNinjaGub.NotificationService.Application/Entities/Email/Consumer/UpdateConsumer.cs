using MassTransit;
using System.Net;
using System.Net.Mail;
using TaskNinjaGub.NotificationService.Application.Entities.Tasks.Domain;

namespace TaskNinjaGub.NotificationService.Application.Entities.Email.Consumer;

public class UpdateConsumer : IConsumer<CatalogTask>
{
    private const string SmtpServer = "smtp.mail.ru";

    private const int SmtpPort = 587;

    private const string SmtpUsername = "taskninjahub@internet.ru";

    private const string SmtpPassword = "SV7dksqkU7U5uBrbykdE";

    private readonly SmtpClient _smtpClient = new(SmtpServer, SmtpPort)
    {
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(SmtpUsername, SmtpPassword),
        EnableSsl = true
    };

    public async System.Threading.Tasks.Task Consume(ConsumeContext<CatalogTask> task)
    {
        var htmlBody = Body.MessageBody.ConstructTaskAssignmentEmailBody(task.Message);

        var message = new MailMessage
        {
            From = new MailAddress("taskninjahub@internet.ru"),
            Subject = "The task you were assigned to has been updated",
            Body = htmlBody,
            IsBodyHtml = true
        };
        message.To.Add(task.Message.TaskExecutor!.Name!);

        await _smtpClient.SendMailAsync(message);
    }
}