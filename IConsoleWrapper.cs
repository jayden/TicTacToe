using System;

namespace TicTacToe
{
    public interface IConsoleWrapper
    {
        void Write(string data);
        void WriteLine();
        void WriteLine(string data);
    }
}
