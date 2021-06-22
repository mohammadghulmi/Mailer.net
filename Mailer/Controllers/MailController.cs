using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using Mailer.Models;
using Microsoft.Extensions.Configuration;

namespace Mailer.Controllers
{
   
    public class MailController : Controller
    {
        private static IConfiguration configuration;
        private static string Sorcefrom;

        public MailController(IConfiguration configuration1)
        {
            configuration = configuration1;
        }
        public async Task<IActionResult> Index([Bind("From,To,Subject,Name,Password,Body")] Mail mail)
        {
            await SendEmailAsync(mail.From, mail.To, mail.Subject, mail.Name, mail.Password, mail.Body);
            return View();

        }
        public async static Task SendEmailAsync(string From,string To,string Subject,string Name,string Password,string Body)
        {
            
             

            try
            {
                string _Password = configuration.GetValue<string>("Password");
                Sorcefrom = configuration.GetValue<string>("Email");
                var Message = new MimeMessage();
                Message.From.Add(new MailboxAddress(Name,Sorcefrom));
                Message.To.Add(new MailboxAddress(To));
                Message.Subject = Subject;
                Message.Body = new TextPart("html")
                {
                    Text = Body
                };

                using (var client = new SmtpClient())
                {
                    

                    
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    

                    await client.AuthenticateAsync(Sorcefrom, Password);
                    await client.SendAsync(Message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message+Sorcefrom);
            }

        }

    }
}
