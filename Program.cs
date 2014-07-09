using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game controller and start a game
            GameController game = new GameController();
            game.initGame();
        }
    }
}
