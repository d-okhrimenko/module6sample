using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.CalcLibrary.Tests
{
    class StubDataProvider : IDataProvider
    {
        public string[] GetLinesFromFile(string fileName)
        {
            return new string[]
            {
                "line 1",
                "",
                "line 1",
                "",
                "line 1",
                "line 1",
                "line 1",
                "",
                "line 1"
            };
        }
    }
}
