//Factory to Instantiare SmtpSender using EmailSenderOptions
using Microsoft.Extensions.Options;
using MailKitSimplified.Sender.Services;
using MailKitSimplified.Sender.Models;

public interface ISmtpSenderFactory
{
    SmtpSender CreateSmtpSender();
}

public class SmtpSenderFactory : ISmtpSenderFactory
{
    private readonly IOptions<EmailSenderOptions> emailSenderOptions;

    public SmtpSenderFactory(IOptions<EmailSenderOptions> emailSenderOptions)
    {
        this.emailSenderOptions = emailSenderOptions;
    }

    public SmtpSender CreateSmtpSender()
    {
        var options = emailSenderOptions.Value;
        return SmtpSender.Create(options);
    }
}