using Application.Common.Models;

namespace Domain.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(EmailRequest request);

    Task SendRegisterEmailAsync(string Username, string To, string Token);
}
