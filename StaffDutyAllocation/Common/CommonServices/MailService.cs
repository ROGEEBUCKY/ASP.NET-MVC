using System;
using System.Net;
using System.Net.Mail;

namespace Common.CommonServices
    {
    public class MailService
        {
        public void SendMail(string mail, string msg)
            {
            try
                {
                MailMessage newMail = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                newMail.From = new MailAddress("rituraj.step2gen@gmail.com", "Rituraj");
                newMail.To.Add(mail);
                newMail.IsBodyHtml = false;
                newMail.Subject = "Duty Assignment Notice";
                newMail.Body = msg;

                smtpClient.EnableSsl = true;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("rituraj.step2gen@gmail.com", "nxbvisedpnsabfbh");
                smtpClient.Send(newMail);
                Console.WriteLine("Mail sent");
                }
            catch (Exception e)
                {
                Console.WriteLine("Error Occured:\n " + e);
                }
            }
        }
    }
