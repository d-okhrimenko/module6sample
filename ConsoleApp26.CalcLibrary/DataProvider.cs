using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.CalcLibrary
{
    public class DataProvider : IDataProvider
    {
        public string[] GetLinesFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
