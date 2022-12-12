


using MimeKit;
using MimeKit.Text;
 using MailKit.Net.Smtp;
using MailKit.Security;
using System.Security.Principal;
using System;

namespace Email
{
    public static class SendSend
    {
        public static void Send()
        {
         
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", "hosseingolmohammadi193201@gmail.com"));
            message.To.Add(new MailboxAddress("Client User", "m.aghaei@parshan.net"));
            message.Subject = "Verify Code";

            message.Body = new TextPart(TextFormat.Text)
            {
                Text = "شروین جووون",

            };

            using (var client = new SmtpClient())
            {
                
                client.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                client.CheckCertificateRevocation = false;
                client.ClientCertificates = null;
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.Auto);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: only needed if the SMTP server requires authentication


                ///
                /// The deactivation of less secure applications prevents you from being able to log in directly with your username and password, but it does not prevent you from being able to generate a specific password for your application. Now, instead of logging in with your google password, you'll log in with a password that you generate for your specific app.

                //The solution is simple and does not require much change:

                //Turn on 2 - Step Verification in your google account.This step is required as Google only allows generating passwords for apps on accounts that have 2 - Step Verification enabled.
                //Go to generate apps password(https://myaccount.google.com/apppasswords) and generate a password for your app.
                                ///
                                client.Authenticate("hosseingolmohammadi193201@gmail.com", "ukffbjlxdcmvbjcy");
                

                client.Send(message);
                client.Disconnect(true);
            };
         













            //var fromAddress = new MailAddress("hosseingolmohammadi193201@gmail.com", "From Name");
            //var toAddress = new MailAddress("hosseingolmohammadi193201@gmail.com", "To Name");
            //const string fromPassword = "0580047970";
            //const string subject = "Subject";
            //const string body = "Body";

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 465,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = true,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            //};

            //var message = new MailMessage(fromAddress, toAddress)
            //{
            //    Subject = subject,
            //    Body = body
            //};

            //smtp.Send(message);

        }
    }
}
