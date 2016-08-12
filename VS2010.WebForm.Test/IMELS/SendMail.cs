using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace IMELS
{
    public class SendMail
    {
        public SendMail() { }

        private string _to = string.Empty;

        /// < summary>     
        /// 收件人地址，多个用“,”号隔开     
        /// < /summary>     
        public string To
        {
            set { _to = value; }
        }

        private string _from = string.Empty;

        /// < summary>     
        /// 发件人地址     
        /// < /summary>     
        public string From
        {
            set { _from = value; }
        }

        private string _fromName = string.Empty;

        /// < summary>     
        /// 发件人显示名称     
        /// < /summary>     
        public string FromName
        {
            set { _fromName = value; }
        }

        private string _cc = string.Empty;

        /// < summary>     
        /// 抄送，多个用“,”号隔开     
        /// < /summary>     
        public string CC
        {
            set { _cc = value; }
        }

        private string _bcc = string.Empty;

        /// < summary>     
        /// 密抄，多个用“,”号隔开     
        /// < /summary>     
        public string BCC
        {
            set { _bcc = value; }
        }

        private string _charset = "GB2312";

        /// < summary>     
        /// 邮件正文的编码     
        /// < /summary>     
        public string Charset
        {
            set { _charset = value; }
        }

        private string _contentType = "html";
        /// < summary>     
        /// 邮件格式(html or txt)     
        /// < /summary>     
        public string ContentType
        {
            set { _contentType = value; }
        }

        private string _subject = string.Empty;
        /// < summary>     
        /// 邮件标题     
        /// < /summary>     
        public string Subject
        {
            set { _subject = value; }
        }

        private string _body = string.Empty;
        /// < summary>     
        /// 邮件内容     
        /// < /summary>     
        public string Body
        {
            set { _body = value; }
        }

        private string _smtp;
        /// < summary>     
        /// SMTP服务器地址     
        /// < /summary>     
        public string Smtp
        {
            set { _smtp = value; }
        }

        private string _username;
        /// < summary>     
        /// SMTP用户名     
        /// < /summary>     
        public string Username
        {
            set { _username = value; }
        }
        /// < summary>     
        ///  SMTP密码     
        /// < /summary>     
        private string _password;

        public string Password
        {
            set { _password = value; }
        }

        private int _port = 25;
        /// < summary>     
        /// SMTP商品     
        /// < /summary>     
        public int Port
        {
            set { _port = value; }
        }

        /// < summary>     
        /// 发送     
        /// < /summary>     
        public void Send()
        {
            MailAddress from = new MailAddress(_from, _fromName);
            MailMessage message = new MailMessage();
            message.From = from;

            string[] toadd = _to.Split(',');
            foreach (string _add in toadd)
            {
                try
                {
                    message.To.Add(new MailAddress(_add));
                }
                catch (Exception e)
                {
                    _error += "To Address Error : " + e.Message + "(" + _add + ");";
                }
            }

            if (_cc != string.Empty)
            {

                string[] ccadd = _cc.Split(',');

                foreach (string _add in ccadd)
                {
                    try
                    {
                        message.CC.Add(new MailAddress(_add));
                    }
                    catch (Exception e)
                    {
                        _error += "CC Address Error : " + e.Message + "(" + _add + ");";
                    }
                }
            }
            if (_bcc != string.Empty)
            {
                string[] bccadd = _bcc.Split(',');

                foreach (string _add in bccadd)
                {
                    try
                    {
                        message.Bcc.Add(new MailAddress(_add));
                    }
                    catch (Exception e)
                    {
                        _error += "BCC Address Error : " + e.Message + "(" + _add + ");";
                    }
                }
            }

            message.Sender = from;
            message.Subject = _subject;
            message.Body = _body;

            if (_contentType == "html" || _contentType == string.Empty)
            {
                message.IsBodyHtml = true;
            }
            else
            {
                message.IsBodyHtml = false;
            }

            message.BodyEncoding = Encoding.GetEncoding(_charset);
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;
            SmtpClient __smtp = new SmtpClient();
            __smtp.Host = _smtp;
            __smtp.Port = _port;
            __smtp.UseDefaultCredentials = false;
            __smtp.Credentials = new System.Net.NetworkCredential(_username, _password);
            __smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                __smtp.Send(message);
            }
            catch (SmtpException e)
            {
                _error += "SMTP Error:" + e.Message + ";";
            }

        }

        private string _error = string.Empty;
        /// < summary>     
        /// 返回错误信息     
        /// < /summary>     
        public string Error
        {
            get { return _error; }
        }
        /// < summary>     
        /// 清空错误信息     
        /// < /summary>     
        public void ClearErr()
        {
            _error = string.Empty;
        }
    }
}
