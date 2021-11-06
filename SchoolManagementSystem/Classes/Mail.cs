using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Classes
{
    internal class Mail
    {
        public async Task SendAsync(string receiverName, string receiverEmail)
        {
            MimeMessage mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Asteilia Support", "bimosiness@gmail.com"));
            mailMessage.To.Add(new MailboxAddress(receiverName, receiverEmail));
            mailMessage.Subject = "Email Verification";
            mailMessage.Body = new TextPart("html")
            {
                Text = GetHTMLTemplate("email-verification.html")
            };

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtpClient.Authenticate("bimosiness@gmail.com", "Su16ta_ali");
                await smtpClient.SendAsync(mailMessage);
                smtpClient.Disconnect(true);
            }
        }

        private string GetHTMLTemplate(string templateName)
        {
            string directoryPath = @"D:\Projects\Visual Studio\SchoolManagementSystem\SchoolManagementSystem\HTML Templates";
            string fileType = "*.html";
            string fileContent = string.Empty;
            string[] files;

            DirectoryInfo directoryInfo;

            directoryInfo = new DirectoryInfo(directoryPath);
            directoryInfo.GetFiles("*.html");

            files = Directory.GetFiles(directoryPath, fileType);

            foreach (string file in files)
            {
                if (Path.GetFileName(file).Equals(templateName))
                {
                    fileContent = File.ReadAllText(directoryPath + @"\" + Path.GetFileName(file));
                    break;
                }
            }

            return fileContent;
        }
    }
}
