using System;

namespace TicTacToe
{
    public class Board
    {
        // constant board dimensions
        public static int rows = 3;
        public static int cols = 3;

        public Node[,] node; // cells on board (9 total)
        public int currentRow, currentCol; // current position on board

        // initializes game board
        public Board()
        {
            node = new Node[rows,cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // create element in array
                    node[r, c] = new Node(r, c);
                }
            }
        }

        // clears contents of the board
        public void init()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    node[r, c].clear();
                }
            }
        }

        public bool isDraw()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // game is not a draw if a space is empty
                    if (node[r, c].content == Player.Empty)
                        return false;
                }
            }

            return true; // no empty spaces and no winner - it's a draw
        }

        // winning patterns in hex
        private int[] winningPatterns = 
        {
           0x1c0, 0x38, 0x7,     // rows
           0x124, 0x92, 0x49,     // column
           0x111, 0x54              // diagonals
        };


        // check if player has won
        public bool hasWon(Player p)
        {
            // starting hex pattern (empty)
            int pattern = 0x0; 

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // if node contains player...
                    if (node[r, c].content == p)
                    {
                        // shift a 1 at the bit position and bit-wise OR with the pattern
                        pattern |= (1 << (r * cols + c));
                    }
                }
            }
            // check
            foreach (var winningPattern in winningPatterns)
            {
                // mask bits and check for a winning pattern
                if ((pattern & winningPattern) == winningPattern)
                    return true;
            }
            return false;
        }

        // draw the board 
        public void draw()
        {
            for (int r = 0; r < rows; r++)
            {
                for ( int c = 0; c < cols; c++)
                {
                    node[r, c].draw();
                    if (c < cols - 1)
                        Console.Write("|");
                }

                Console.WriteLine();
                if (r < rows - 1)
                    Console.WriteLine("-----------");
            }
        }
    }
}
