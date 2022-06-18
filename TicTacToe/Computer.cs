using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Computer : IPlayer
    {
        // Searches board array for empty possible spaces to play turn
        public static List<(int, int)> GetPossibleMoves(List<List<int>> board)
        {
            var moves = new List<(int, int)>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row][col] == ' ')
                    {
                        moves.Add((row, col));
                    }
                }
            }
            return moves;
        }

        // Picks a random free space from 'GetPossibleMoves' list created above
        public static (int row, int col) RandomMove(List<List<int>> board)
        {
            var random = new Random();
            var moves = GetPossibleMoves(board);
            var computerTurn = moves[random.Next(moves.Count)];
            return computerTurn;
        }

        // Method to evauluate turn values for use in Alpha-Beta algorithm
        public double Evaluate()
        {
            throw new NotImplementedException();
        }

        // Method for computer player to determine optimal turn
        public static void AlphaBetaMove()
        {
            throw new NotImplementedException();
        }
    }
}