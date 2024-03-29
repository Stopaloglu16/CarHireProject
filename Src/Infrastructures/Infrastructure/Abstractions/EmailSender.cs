using Application.Common.Models;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Infrastructure.Abstractions;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendEmailAsync(EmailRequest request)
    {

        //Chaging to https://www.mailinator.com

        var emailClient = new SmtpClient("localhost");

        var message = new MailMessage
        {
            From = new MailAddress(request.FromMail),
            Subject = request.Subject,
            Body = request.Body
        };

        foreach (string to in request.ToMail)
        {
            message.To.Add(new MailAddress(to));
        }

        //TODO:EmailService if there was error, try at least three times. 
        try
        {
            await emailClient.SendMailAsync(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CleanArchitecture EmailService: Unhandled Exception for Request {@Request}", request);
        }

        _logger.LogWarning($"Sending email to {request.ToMail} from {request.FromMail} with subject {request.Subject}.");

    }


    public static void SendRegister(string Useremail, string Username, string SystemCode)
    {
        try
        {
            //Chaging to https://www.mailinator.com

            System.Net.Mail.MailMessage myMailMessage = new System.Net.Mail.MailMessage();
            myMailMessage.From = new MailAddress("No-Reply@business.co.uk");
            myMailMessage.To.Add("testemail@hotmail.com");

            //myMailMessage.To.Add(Useremail);

            string MessageBody = "";

            string HtmlBegin = "<html><head><style> body { background: #eaeff1;  text-align: center; } " +
                               "table { border: 1px solid #1da5d1; border-radius: 13px;border-spacing: 0;background-color:white;} " +
                                ".welcometxt { font-size: x-large; color: #1da5d1 } " +
                                "</style></head><body>";

            MessageBody = " <table style='width:50%;'><tbody><tr><td> <img  style='width:10%;' src='https://localhost:7056/img/carhire.jpeg'> </td></tr>" +
                            "<tr><td> <h2> <span class='welcometxt'>Welcome to Portalnow!</span></h2></td></tr>" +
                            "<tr><td>Click below to verify your account.</br> <a href='https://localhost:7056/register/" + Username + "/" + SystemCode + "'>here</a></td></tr>" +
                            "<tr><td>Username: </br>" + Username + "</td></tr>" +
                            "</tbody></table>";


            string HtmlEnd = "</body></html>";


            myMailMessage.Subject = "Welcome to carhire";

            myMailMessage.Body = HtmlBegin + MessageBody + HtmlEnd;
            myMailMessage.IsBodyHtml = true;


            SmtpClient smtp = new SmtpClient();
            smtp.Host = "test.server.co.uk";
            smtp.UseDefaultCredentials = true;
            //smtp.EnableSsl = true;
            //smtp.Port = 587;

            smtp.Send(myMailMessage);

        }
        catch (Exception)
        {
            ;
        }
    }

   
}
