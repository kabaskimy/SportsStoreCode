using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreApp.MVC.Domain.Abstract;
using SportsStoreApp.MVC.Domain.Entities;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SportsStoreApp.MVC.Domain.Concrete
{

    public class EmailSetting
    {
        public string MailToAddress = "laoxu1102@tom.com";
        public string MailFromAddress = "kabaskimy@163.com";
        public bool UseSSL = true;
        public string UserName = "kabaskimy";
        public string Password = "13682530904";
        public string ServerName = "smtp.163.com";
        public int Port = 25;
        public bool WriteAsFile = false;
        public string FileLocation = @"F:\Email_File";
    }
    public class EmailOrderProcessor:IOrderProcessor
    {
        private EmailSetting emailSetting;
        public EmailOrderProcessor(EmailSetting setting)
        {
            emailSetting = setting;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = emailSetting.UseSSL;
                client.Host = emailSetting.ServerName;
                client.Port = emailSetting.Port;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(emailSetting.UserName, emailSetting.Password);
                if (emailSetting.WriteAsFile)
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    client.PickupDirectoryLocation = emailSetting.FileLocation;
                    client.EnableSsl = false;
                }

                StringBuilder mailBody = new System.Text.StringBuilder();
                mailBody.AppendLine("A new order has been submit")
                .AppendLine("--------------------------")
                .AppendLine("Lines:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    mailBody.AppendFormat("{0:c} x {1}  (subtotal:{2:c}", line.Product.Price, line.Quantity, subtotal);
                }

                MailMessage message = new MailMessage(emailSetting.MailFromAddress, emailSetting.MailToAddress, "New submit order", mailBody.ToString());

                if (emailSetting.WriteAsFile)
                {
                    message.BodyEncoding = Encoding.UTF8;
                }

                client.Send(message);
            }
        }

    }
}
