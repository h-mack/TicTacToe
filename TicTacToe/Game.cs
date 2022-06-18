using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Game : IGame
    {
        // Didn't feel the need to leave comments on what each method does
        // as their names should speak for themselves

        public static bool CheckValidMove(char player, int row, int col)
        {
            // Move is out of bounds
            if ((row > 2 || row < 0) && (col > 2 || col < 0)) 
            { 
                return false; 
            }

            // Space is already taken
            if (Program.History[Program.movesPlayed][row][col] != ' ')
            {
                return false; 
            }

            return true;
        }

        public static bool CheckWinner(char player, List<List<int>> board)
        {
            // Check row win conditions
            if (board[0][0] == player && board[0][1] == player && board[0][2] == player) { return true; }
            if (board[1][0] == player && board[1][1] == player && board[1][2] == player) { return true; }
            if (board[2][0] == player && board[2][1] == player && board[2][2] == player) { return true; }

            // Check column win conditions
            if (board[0][0] == player && board[1][0] == player && board[2][0] == player) { return true; }
            if (board[0][1] == player && board[1][1] == player && board[2][1] == player) { return true; }
            if (board[0][2] == player && board[1][2] == player && board[2][2] == player) { return true; }

            // Check diagonal win conditions
            if (board[0][0] == player && board[1][1] == player && board[2][2] == player) { return true; }
            if (board[0][2] == player && board[1][1] == player && board[2][0] == player) { return true; }

            return false;
        }

        public static bool CheckDraw()
        {
            if (Program.movesPlayed == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}