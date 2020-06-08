using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Net.Configuration;
using System.Web.Configuration;

namespace BookStoreMisc
{
    public class MailModel
    {
        public string[] to;
        public string[] cc;
        public string subject;
        public string body;
        public bool isbodyhtml;
        public string[] attachments;
        public bool Send()
        {
            SmtpSection cfg = NetSectionGroup.GetSectionGroup(WebConfigurationManager.OpenWebConfiguration("~/Web.config")).MailSettings.Smtp;
            MailAddress mailAddress = new MailAddress(cfg.From);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = mailAddress;
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.Default;
            mailMessage.Priority = MailPriority.High;
            mailMessage.IsBodyHtml = isbodyhtml;
            if (to != null)
                for (int i = 0; i < to.Length; i++)
                    mailMessage.To.Add(to[i]);

            if (cc != null)
                for (int i = 0; i < cc.Length; i++)
                    mailMessage.CC.Add(cc[i]);

            try
            {
                if (attachments != null && attachments.Length > 0)
                {
                    Attachment attachment = null;
                    foreach (string path in attachments)
                    {
                        attachment = new Attachment(path);
                        mailMessage.Attachments.Add(attachment);
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("附件处错误:" + err);
            }
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(cfg.Network.UserName, cfg.Network.Password);

            client.Port = cfg.Network.Port;
            client.Host = cfg.Network.Host;
            client.EnableSsl = true;
            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }

    public static class MailValidation
    {
        public static bool SendValidation(string to, string code)
        {
            MailModel mail = new MailModel();
            mail.to = new string[] { to };
            mail.subject = "欢迎来到CC书店";
            mail.body = "CC书店 验证码：" + code;
            mail.isbodyhtml = true;
            if (mail.Send())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}