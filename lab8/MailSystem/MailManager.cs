using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            EventHandler<MailArrivedEventArgs> eventHandler = MailArrived;

            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        public void SimulateMailArrived(string title, string body)
        {
            OnMailArrived(new MailArrivedEventArgs(title,body));
        }


    }
}
