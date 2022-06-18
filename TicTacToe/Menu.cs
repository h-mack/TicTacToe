using System;

namespace TicTacToe
{
    class Menu : IMenu
    {
        // Didn't feel the need to leave comments on what each method does
        // as their names should speak for themselves

        public static void DisplayMenu(char player)
        {
            Console.WriteLine("\nPlayer " + player + " turn.\n");
            Console.WriteLine("Please enter one of the following commands:");
            Console.WriteLine("\nFunction       Format\n");
            Console.WriteLine("Game rules     (Rules)");
            Console.WriteLine("Save game      (Save)");
            Console.WriteLine("Load game      (Load)");
            Console.WriteLine("Restart game   (Restart)");
            Console.WriteLine("Undo move      (Undo)");
            Console.WriteLine("Redo move      (Redo)");
            Console.WriteLine("\nPlay turn      (col row)");
            Console.Write("\n             >> ");
        }

        public static void DisplayGameRules(char player)
        {
            Console.Clear();
            Console.WriteLine("The game is played on a grid that's 3 squares by 3 squares.");
            Console.WriteLine("You are 'X', your friend (or computer opponent) is 'O'.");
            Console.WriteLine("Players take turns putting their marks in empty squares.");
            Console.WriteLine("The first player to get 3 of their marks in a row (up, down, " +
                "\nacross or diagonally) is the winner.");
            Console.WriteLine("When all 9 squares are full, the game is over. If no player " +
                "\nhas 3 marks in a row, the game ends in a tie.");
            Console.WriteLine("\nPress Enter to return to Menu options.");
            Console.ReadLine();
            Player.UserInputValidation(player);
        }

        public static string SelectOpponentType()
        {
            Console.WriteLine("Please select opponent type");
            Console.Write("\nEnter 'H' for human opponent or enter 'C' for computer opponent >> ");
            string opponentType = Console.ReadLine();
            return opponentType;
        }

        public static string SelectComputerDifficulty()
        {
            Console.WriteLine("\nPlease select computer diffculty");
            Console.Write("\nEnter 'E' for easy or enter 'H' for hard computer opponent >> ");
            string computerDifficulty = Console.ReadLine();
            return computerDifficulty;
        }
    }
}