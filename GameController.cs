using System;
using System.Linq;

namespace TicTacToe
{
    public class GameController
    {
        private Board board; // game board
        private GameState currentState; // current state of game
        private Player currentPlayer; // current player
        private PerfectPlayer ai;

        public GameController()
        {
        }

        public void initGame()
        {
            // create a board, initialize it, and create an AI player
            board = new Board();
            board.init();
            board.draw();
            ai = new PerfectPlayer(board);

            // player X goes first
            currentPlayer = Player.PlayerX;
            currentState = GameState.Playing;

            do
            {
                // update game with move and re-draw the board
                playerMove(currentPlayer);
                board.draw();
                updateGameState(currentPlayer);

                // announce conclusion of game
                if (currentState == GameState.XWon)
                    Console.WriteLine("X won!");
                else if (currentState == GameState.OWon)
                    Console.WriteLine("O won!");
                else if (currentState == GameState.Draw)
                    Console.WriteLine("It's a draw!");

                // switch player
                currentPlayer = currentPlayer == Player.PlayerX ? Player.PlayerO : Player.PlayerX;
            } while (currentState == GameState.Playing); // repeat until game is over
        }

        public void playerMove(Player player)
        {
            bool invalidMove = true;
            do
            {
                int row = -1;
                int col = -1;

                if (player == Player.PlayerX)
                {
                    bool invalidInput;
                    // ask for valid move and repeat if invalid
                    do
                    {
                        Console.Write("Player X, select a move from 1-{0}: ", board.node.Length);
                        string input = Console.ReadLine().Trim();
                        int pos;

                        if (input.All(char.IsDigit) && int.TryParse(input, out pos) && (pos >= 1 && pos <= 9) )
                        {
                            invalidInput = false;
                            board.TraverseBoard((r, c) => { if (board.node[r, c].Position == pos) { row = r; col = c; } }); 

                        }
                        else
                        {
                            Console.WriteLine("Invalid move. Move must be between 1 and {0}.", board.node.Length);
                            invalidInput = true;
                        }

                    } while(invalidInput);
                }
                else
                {
                    // get move for AI player
                    int[] computerMove = ai.move();
                    row = computerMove[0];
                    col = computerMove[1];
                    Console.WriteLine("Computer has moved to {0}!", board.node[row, col].Position);
                }

                // check for valid row/col selection and if the node is empty
                if ( (row >= 0 && row < Board.rows) && (col >= 0 && col < Board.cols) && board.node[row, col].content == Player.Empty)
                {
                    board.node[row, col].content = player;
                    board.currentRow = row;
                    board.currentCol = col;
                    invalidMove = false;
                }
                else
                    Console.WriteLine("This space is already taken. Please choose another move");
            } while (invalidMove);
        }

        // change game state if the game is over
        public void updateGameState(Player player)
        {
            if (board.hasWon(player))
                currentState = player == Player.PlayerX ? GameState.XWon : GameState.OWon;
            else if (board.isDraw())
                currentState = GameState.Draw;
        }
    }
}
