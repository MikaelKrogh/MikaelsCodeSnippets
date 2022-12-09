using System;
using System.Collections.Generic;
using System.IO;
namespace OutlookSender {
    class Program {

         static string[] mailInfo = File.ReadAllLines(@"C:\Users\45298\Documents\Skole\EmailTester.txt");
         public static string smtpServer = "smtp-mail.outlook.com";
        static void Main(string[] args) {
            ProductManager manager = new ProductManager();
            while (1 > 0)
            {
            manager.Products[0].Amount = Convert.ToInt32(Console.ReadLine());
            }
        }
         public static void SendEmail(string smtpServer) {
            //Send teh High priority Email  
            EmailManager mailMan = new EmailManager(smtpServer);

            EmailSendConfigure myConfig = new EmailSendConfigure();
            // replace with your email userName  
            myConfig.ClientCredentialUserName = mailInfo[0];
            // replace with your email account password
            myConfig.ClientCredentialPassword = mailInfo[1];
            myConfig.TOs = new string[] { "EMAILADRESSE" }; //Modtager
            myConfig.CCs = new string[] { };
            myConfig.From = mailInfo[0];
            myConfig.FromDisplayName = "Boss man";
            myConfig.Priority = System.Net.Mail.MailPriority.Normal;
            myConfig.Subject = "check your phone";

            EmailContent myContent = new EmailContent();
            myContent.Content = "The following URLs were down - 1. Foo, 2. bar";
            mailMan.SendMail(myConfig, myContent);
            Console.WriteLine("Email sent");
        }
    }
}
