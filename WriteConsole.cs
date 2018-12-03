using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class WriteConsole : IWriter
    {
        public void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void WriteInfo(string info)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
