using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Stock
{
    public delegate void MailHandler();

    public class MailSender
    {
        EventArgs e = null;
        public bool SentMail = false;

        public void SendMail()
        {
            SentMail = true;
        }

        public void DontSend()
        {
            SentMail = false;
        }

        public void ConsiderToSendMail(MailHandler mailHandler)
        {
            mailHandler();
        }
    }
}
