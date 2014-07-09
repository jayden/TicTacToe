using System;

namespace TicTacToe
{
    //Node
    public class Node
    {
        public Player content;
        int row, col;

        public Node(int row, int col)
        {
            // set node to empty with coordinates
            this.row = row;
            this.col = col;
            clear();
        }

        public void clear()
        {
            // initialize all nodes as empty
            content = Player.Empty;
        }

        // draws the appropriate marker based on player type
        public void draw()
        {
            switch(content)
            {
                case Player.PlayerX:
                    Console.Write(" X "); break;
                case Player.PlayerO:
                    Console.Write(" O "); break;
                case Player.Empty:
                    Console.Write("   "); break;
            }
        }
    }
}
