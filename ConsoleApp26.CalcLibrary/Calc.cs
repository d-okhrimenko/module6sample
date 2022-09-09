using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.CalcLibrary
{
    public class Calc
    {
        IDataProvider provider;
        ISmsService service;

        public Calc()
        {
            provider = new DataProvider();
        }

        public Calc(IDataProvider provider)
        {
            this.provider = provider;
        }

        public Calc(IDataProvider provider, ISmsService service) : this(provider)
        {
            this.service = service;
        }

        public int Sum(int x, int y)
        {
            Check(x);
            return x + y;
        }

        public int Div(int x, int y)
        {
            return x / y;
        }

        public bool Check(int value)
        {
            if (value != 0 || value != 100)
                return true;
            return false;
        }

        public int GetEmptyLines(string fileName)
        {
            var lines = provider.GetLinesFromFile(fileName);

            int counter = 0;
            foreach (var line in lines)
            {
                if(string.IsNullOrEmpty(line))
                {
                    counter++;
                }
            }

            if (service != null)
            {
                string number = service.GetAdminNumber();
                service.SendSms(counter + " empty lines", number);
            }

            return counter;
        }
    }
}
