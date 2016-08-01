using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        //Where is the timer?
        static void Main(string[] args)
        {
            MailManager mailManager = new MailManager();
            mailManager.MailArrived += MailArrivedCon;
            mailManager.SimulateMailArrived("BLABLA","BLABLABLA");
            mailManager.SimulateMailArrived("BLABDD", "BLABLADDD");
        }

        private static void MailArrivedCon(object sender, MailArrivedEventArgs e)
        {

            Console.WriteLine("Title: " + e.Title);
            Console.WriteLine("Body: " + e.Body);
        }

    }
}
