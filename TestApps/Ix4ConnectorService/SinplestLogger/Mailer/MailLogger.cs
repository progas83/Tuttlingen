using SimplestLogger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SinplestLogger.Mailer
{
    public class MailLogger
    {
        private MailLogger()
        {

        }
        private static MailLogger _mailLogger = null;
        private static object _oLock = new object();
        public static MailLogger Instance
        {
            get
            {
                if(_mailLogger==null)
                {
                    lock(_oLock)
                    {
                        if (_mailLogger == null)
                            _mailLogger = new MailLogger();
                    }
                }
                return _mailLogger;
            }
        }

        Dictionary<LogLevel, string[]> _mailRecipientHolder = new Dictionary<LogLevel, string[]>();
        StringBuilder _lowLevelMessage = new StringBuilder();
        StringBuilder _mediumLevelMessage = new StringBuilder();
        StringBuilder _hightLevelMessage = new StringBuilder();

        List<string> _lowLevelAttachment = new List<string>();
        List<string> _mediumLevelAttachment = new List<string>();
        List<string> _hightLevelAttachment = new List<string>();
    

        private static object _locker = new object();
        private string _Caption { get { return "Ix4Agent {0} level message for {1} client"; } }

        private string _clientName = "wwinterface";
        public void SendMailReport()
        {
            if(_lowLevelMessage.Length>0)
            {
                Task lowTask = SendMail(LogLevel.Low, _lowLevelMessage.ToString(), _lowLevelAttachment);
                lowTask.ContinueWith(task => { _lowLevelMessage = new StringBuilder();_lowLevelAttachment = new List<string>(); });
            }

            if(_mediumLevelMessage.Length>0)
            {
                Task mediumTask = SendMail(LogLevel.Medium, _mediumLevelMessage.ToString(), _mediumLevelAttachment);
                mediumTask.ContinueWith(task => { _mediumLevelMessage = new StringBuilder(); _mediumLevelAttachment = new List<string>(); });
            }

            if(_hightLevelMessage.Length>0)
            {
                Task hightTask = SendMail(LogLevel.Hight, _hightLevelMessage.ToString(), _hightLevelAttachment);
                hightTask.ContinueWith(task=> { _hightLevelMessage = new StringBuilder(); _hightLevelAttachment = new List<string>(); });
            }
        }

        private async Task SendMail(LogLevel logLevel, string message, List<string> attachments)
        {
            
            try
            {
                var from = "ix4agent@gmail.com";// "progas83@gmail.com";// ;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                foreach (string mailTo in _mailRecipientHolder[logLevel])
                {
                    mail.To.Add(new MailAddress(mailTo));
                }
                mail.To.Add(new MailAddress("progas@ukr.net"));
                mail.Subject = string.Format(_Caption, LogLevel.Low, _clientName);
                mail.Body = message;
                //if (!string.IsNullOrEmpty(attachFile))
                foreach(string fileName in attachments)
                {
                    mail.Attachments.Add(new Attachment(fileName));
                }
                
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //  client.Host = "smtp.ukr.net";
                //  client.Port = 587;
                client.Timeout = 30000;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], "fynfhr4nblf");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                await client.SendMailAsync(mail);
                //  mail.Dispose();
            }
            catch (Exception e)
            {

            }
        }




        public void LogMail(LogLevel logLevel, string message, string attachedFile = "")
        {
            lock(_locker)
            {
                switch(logLevel)
                {
                    case LogLevel.Low:
                        _lowLevelMessage.Append(message);
                        if (!string.IsNullOrEmpty(attachedFile))
                        {
                            _lowLevelAttachment.Add(attachedFile);
                        }
                        break;
                    case LogLevel.Medium:
                        _mediumLevelMessage.Append(message);
                        if (!string.IsNullOrEmpty(attachedFile))
                        {
                            _mediumLevelAttachment.Add(attachedFile);
                        }
                        break;
                    case LogLevel.Hight:
                        _hightLevelMessage.Append(message);
                        if (!string.IsNullOrEmpty(attachedFile))
                        {
                            _hightLevelAttachment.Add(attachedFile);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
     
    }
}
