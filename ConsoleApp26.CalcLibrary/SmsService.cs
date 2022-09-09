using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.CalcLibrary
{
    public class SmsService : ISmsService
    {
        public void SendSms(string message, string phone)
        {
            Console.WriteLine(message + " sent to " + phone);
        }

        public string GetAdminNumber()
        {
            return "+380501231232";
        }
    }
}
