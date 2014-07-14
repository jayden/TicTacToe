using System;

namespace TicTacToe
{
    //Node
    public class Node
    {
        public Player content;
        private int row, col;
        private static int position = 0;

        public int Position { get; set; }
        public int Row { get {return row;} }
        public int Col { get {return col;} }

        public Node(int row, int col)
        {
            // set node to empty with coordinates
            this.row = row;
            this.col = col;
            this.Position = ++position;
        }

        public void clear()
        {
            // initialize all nodes as empty
            content = Player.Empty;
        }

        // draws the appropriate marker based on player type
        public void draw(IConsoleWrapper consoleWrapper)
        {
            switch(content)
            {
                case Player.PlayerX:
                    consoleWrapper.Write(" X "); break;
                case Player.PlayerO:
                    consoleWrapper.Write(" O "); break;
                case Player.Empty:
                    consoleWrapper.Write("   "); break;
            }
        }
    }
}
