using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Modikhana.Commom
{
    public class SendMail
    {
        public bool SendEmailMethod(String emailContent, string strSubject, string strTo, String strBcc, String strHostName, String strUsername, String strPassword, String strFrom, Boolean blnEnableSSL, Int32 Port, Boolean IsAsyn)
        {
            try
            {
                MailMessage mm = new MailMessage(strFrom, strTo);
                mm.Subject = strSubject;
                if (strBcc != String.Empty)
                    mm.Bcc.Add(strBcc);
                mm.Body = emailContent;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                Object state = mm;
                smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                smtp.EnableSsl = blnEnableSSL;
                smtp.Host = strHostName;
                smtp.Port = Port;
                smtp.Credentials = new System.Net.NetworkCredential(strUsername, strPassword);
                if (IsAsyn == true)
                {
                    smtp.SendAsync(mm, state);
                }
                else
                {
                    smtp.Send(mm);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error != null)
            {
            }
        }
    }
}

