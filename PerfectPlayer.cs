using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class PerfectPlayer
    {
        private int rows = Board.rows;
        private int cols = Board.cols;
        private Board board;
        private Node[,] node;
        private Player player;
        private Player enemy;

        public PerfectPlayer(Board board)
        {
            this.board = board;
            node = board.node;
            setPlayer(Player.PlayerO);
        }

        public void setPlayer(Player player)
        {
            this.player = player;
            enemy = player == Player.PlayerX ? Player.PlayerO : Player.PlayerX;
        }

        public int[] move()
        {
            int[] result = minimax(0, player);
            return new int[] { result[1], result[2] }; //row, col
        }

        private int[] minimax(int depth, Player p)
        {
            // Generate all possible moves in a List of arrays
            List<int[]> availableMoves = generateMoves();
            // player is maximizing, enemy is minimizing
            int bestScore = p == player ? int.MinValue : int.MaxValue;
            int currentScore;
            int bestRow = -1;
            int bestCol = -1;
            // if there are no more available moves, evaluate score
            if (availableMoves.Count == 0)
            {
                bestScore = evaluateScore(depth);
            }
            else
            {
                foreach (int[] move in availableMoves)
                {
                    // test this move
                    node[move[0], move[1]].content = p;

                    if (p == player)
                    {
                        // calculate the minimax at this node of the enemy
                        currentScore = minimax(depth + 1, enemy)[0];
                        if (currentScore > bestScore)
                        {
                            bestScore = currentScore;
                            bestRow = move[0];
                            bestCol = move[1];
                        }
                    }
                    else
                    {
                        // calculate the minimax at this node of the player
                        currentScore = minimax(depth + 1, player)[0];
                        if (currentScore < bestScore)
                        {
                            bestScore = currentScore;
                            bestRow = move[0];
                            bestCol = move[1];
                        }
                    }
                    // undo move
                    node[move[0], move[1]].content = Player.Empty;
                }
            }
            return new int[] { bestScore, bestRow, bestCol };
        }

        // Find all available moves
        private List<int[]> generateMoves()
        {
            List<int[]> availableMoves = new List<int[]>();
            // if game is over, no more moves are generated
            if (board.hasWon(player) || board.hasWon(enemy))
            {
                return availableMoves; // return an empty list
            }
            // else, iterate through board and look for empty nodes
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (node[r, c].content == Player.Empty)
                        availableMoves.Add(new int[] { r, c });
                }
            }
            return availableMoves;
        }

        private int evaluateScore(int depth)
        {
            int baseScore = 10;

            // if maximizing player, deduct depth and return positive score; else return negative
            if (board.hasWon(player))
                return baseScore - depth;
            else if (board.hasWon(enemy))
                return depth - baseScore;
            else
                return 0;
        }
    }
}
