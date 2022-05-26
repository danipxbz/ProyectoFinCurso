using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.ViewModel;

namespace VLTMTool.Controller2
{
    public class IncidenceNotifications
    {
        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        VMTickets Ticket;
        public string subject { get; set; }
        public string body { get; set; }
        public List<string> Emails { get; set; }
        AutoTicketGenerationController controller = CompositionRoot.Resolve<AutoTicketGenerationController>();

        public IncidenceNotifications(VMTickets ticket)
        {
            this.Ticket = ticket;
        }
        public void SendNotify()
        {
            var e = ConfigurationManager.AppSettings["mailSendAccount"];

            mail.From = new MailAddress(e);
            foreach (string email in Emails)
                mail.To.Add(email);

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();

            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = ConfigurationManager.AppSettings["mailHost"];
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["mailPort"]);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"]);
            smtp.Timeout = 1000000;

            smtp.Send(mail);
        }
    }
}
