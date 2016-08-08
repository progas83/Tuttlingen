using Ix4Models;
using SimplestLogger.VisualLogging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimplestLogger
{
    public class Logger
    {
        private static Logger _logger;
        private static object _padlock = new object();
        private static StreamWriter _streamWriterFile;
        //   private static readonly _logFilename = CurrentServiceInformation.LoggerFileName;
        private const string _newLine = "-------------Date: {0} | Time: {1}--------------------------------------------------------------------------";
        private Logger()
        {
            _streamWriterFile = new StreamWriter(new FileStream(CurrentServiceInformation.LoggerFileName, System.IO.FileMode.Append));
        }

        public static Logger GetLogger()
        {

            if (_logger == null)
            {
                lock (_padlock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }

            return _logger;
        }
        private static object _streamLock = new object();
        private string _mailToAdress = "progas@ukr.net";
        public void Log(string message)
        {
            lock (_streamLock)
            {
                _streamWriterFile.WriteLine(string.Format(_newLine, DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));
                _streamWriterFile.WriteLine(message);
                _streamWriterFile.Flush();
              //  SendMail(_mailToAdress, "WeinWelt", message);
            }

        }

        private static void SendMail(string mailto, string caption, string message)
        {
            try
            {
                var from = "progas@gmail.com";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                //if (!string.IsNullOrEmpty(attachFile))
                //    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], "ghjnbdjht4bt");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                
                mail.Dispose();
            }
            catch (Exception e)
            {
                _streamWriterFile.WriteLine(string.Format(_newLine, DateTime.UtcNow.ToShortDateString(), DateTime.UtcNow.ToShortTimeString()));
                _streamWriterFile.WriteLine("Mail.Send: " + e.Message);
                _streamWriterFile.Flush();
            }
        }

        public void Log(Exception exception)
        {
            Log(exception.ToString());
            Log("Exception message");
            Log(exception.Message);
        }

        public void Log(object o, string propertyName)
        {
            if (o == null)
            {
                string res = string.Format("This property {0} is null", propertyName);
                Log(res);
            }
        }
    }
}
