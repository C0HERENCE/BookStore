using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace BookStoreMisc
{
    public class MailModel
    {
        public string from;
        public string[] to;
        public string[] cc;
        public string subject;
        public string body;
        public string pwd;
        public string host;
        public bool isbodyhtml;
        public string[] attachments;
        public bool Send()
        {
            MailAddress mailAddress = new MailAddress(from);
            MailMessage mailMessage = new MailMessage();
            if (to != null)
            {
                for (int i = 0; i < to.Length; i++)
                    mailMessage.To.Add(to[i]);
            }

            if (cc != null)
            {
                for (int i = 0; i < cc.Length; i++)
                    mailMessage.CC.Add(cc[i]);
            }

            mailMessage.From = mailAddress;
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.BodyEncoding = Encoding.Default;
            mailMessage.Priority = MailPriority.High;
            mailMessage.IsBodyHtml = isbodyhtml;
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
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(from, pwd);
            smtp.Host = host;
            try
            {
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public static class MailValidation
    {
        public static bool SendValidation(string to, string msg)
        {
            MailModel mail = new MailModel();
            mail.from = "goodmorningbye@163.com";
            mail.pwd = "xiepan826809";
            mail.to = new string[] { to };
            mail.host = "smtp.163.com";
            mail.subject = "CC书店 新用户验证";
            mail.body = "验证码：" + msg;
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