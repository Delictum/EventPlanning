using System.Linq;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EventPlanning.Mvc.Models;
using EventPlanning.Mvc.Models.Entities;

namespace EventPlanning.Mvc.Jobs
{
    public class EmailSender : IJob
    {
        public const int GmailSmtpSendPort = 587;
        public const string GmailSmtpSendAdress = "smtp.gmail.com";
        public const string SenderEmail = "email.event.planning@gmail.com";
        public const string SenderPasswordEmail = "Qwe/123$";

        public async Task Execute(IJobExecutionContext context)
        {

            var events = new EventPlanningContext().Events.Where(e => e.EventVisible).ToList();
            var currentEvents = new StringBuilder();

            currentEvents.Append("Current events are currently available:\n");
            foreach (var @event in events)
            {
                currentEvents.Append(@event.EventTitle).Append(" (").Append(@event.EventDate).Append(");\n");
            }
            currentEvents.Append("Sign up and participate!\nRespectfully, Event planning!");

            var users = new ApplicationDbContext().Users.ToList();

            foreach (var user in users)
            {
                using (var message = new MailMessage(SenderEmail, user.Email))
                {
                    message.Subject = "Newsletter";
                    message.Body = currentEvents.ToString();

                    using (var client = new SmtpClient
                    {
                        EnableSsl = true,
                        Host = GmailSmtpSendAdress,
                        Port = GmailSmtpSendPort,
                        Credentials = new NetworkCredential(SenderEmail, SenderPasswordEmail)
                    })

                    {
                        await client.SendMailAsync(message);
                    }
                }
            }
        }
    }
}