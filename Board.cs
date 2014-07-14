using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicTacToe
{
    public class Board
    {
        // constant board dimensions
        public static int rows = 3;
        public static int cols = 3;

        public Node[,] node; // cells on board (9 total)
        public int currentRow, currentCol; // current position on board
        private ConsoleWrapper wrapper;

        // initializes game board
        public Board()
        {
            node = new Node[rows,cols];
            TraverseBoard((r, c) => node[r, c] = new Node(r, c));
            wrapper = new ConsoleWrapper();
        }

        // clears contents of the board
        public void init()
        {
            TraverseBoard((r, c) => node[r, c].clear());
        }

        public bool isDraw()
        {
            bool isDraw = true;
            // if any spaces are empty, game is not over
            TraverseBoard((r, c) => { if (node[r, c].content == Player.Empty) isDraw = false; } );

            // no empty spaces and no winner - it's a draw
            return isDraw;
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

            TraverseBoard( (r, c) => { if (node[r, c].content == p) pattern |= (1 << (r * cols + c)); });

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
            Action<int, int> drawColumns = (r, c) =>
            {
                node[r, c].draw(wrapper);
                if (c < cols - 1)
                    wrapper.Write("|");
            };

            Action<int> drawRows = r =>
            {
                Console.WriteLine();
                if (r < rows - 1)
                    wrapper.WriteLine("-----------");
            };

            TraverseBoard(drawColumns, drawRows);
        }

        // Board traversal function. action2 is an optional parameter
        public void TraverseBoard(Action<int, int> action, Action<int> action2 = null)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    action(r, c);
                }
                // if parameter is not null, use correct value
                if (action2 != null)
                    action2(r);
            }
        }
    }
}
