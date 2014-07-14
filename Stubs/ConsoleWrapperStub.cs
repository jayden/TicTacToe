using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleWrapperStub : IConsoleWrapper
    {
        public ConsoleWrapperStub()
        {
            
        }
        
        public string output = string.Empty;

        public void Write(string data)
        {
            output = data;
        }

        public void WriteLine()
        {
            output = string.Empty;
        }

        public void WriteLine(string data)
        {
            output = data;
        }

    }
}
