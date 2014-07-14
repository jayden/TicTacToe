using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string data)
        {
            Console.Write(data);
        }

        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

    }
}
