﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class SendEmail
    {
        public static void SendRegister(string Useremail, string Username, string SystemCode)
        {
            try
            {
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
}
