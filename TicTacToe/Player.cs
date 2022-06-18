using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{

    class Player : IPlayer
    {
        // Very short method which probably isn't necessary but conforms to the interface framework        
        public static void MakeMove(char player, List<List<int>> board, int row, int col)
        {
            board[row][col] = player;
        }

        // Switch method to perform validation check on user input against
        // all possible functions user can perform
        public static (int Col, int Row) UserInputValidation(char player)
        {
            Console.Clear();

            // Quick workaround to address move de-sync issue
            var mp = 0;
            if (Program.movesPlayed == 0)
            {
                mp = 0;
            }
            else
            {
                mp = Program.movesPlayed;
            }
            Board.PrintBoard(Program.History[mp]);

            Menu.DisplayMenu(player);
            // Made userInput ToLower() so that there are no case sensitivity input issues
            string userInput = Console.ReadLine().ToLower();

            while (true)
            {
                switch (userInput)
                {
                    case "rules":
                        Menu.DisplayGameRules(player);
                        break;
                    case "save":
                        Console.Write("Please enter save game file name >> ");
                        string saveName = Console.ReadLine() + ".xml";
                        Board.SaveGame(Program.History, saveName);
                        break;
                    case "load":
                        Console.Write("Good luck guessing the filename! >> ");
                        string loadName = Console.ReadLine() + ".xml";
                        Program.History = Board.LoadGame<List<List<List<int>>>>(loadName);
                        Program.movesPlayed = Program.History.IndexOf(Program.History.Skip(1).FirstOrDefault(board =>

                            board.SelectMany(w => w).All(w => w == ' ')
                        ))-1;
                        if (Program.movesPlayed % 2 == 0)
                        {
                            Program.player = 'X';
                        }
                        else
                        {
                            Program.player = 'O';
                        }
                        break;
                    case "restart":
                        Board.RestartGame();
                        break;
                    case "undo":
                        Board.UndoMove();
                        break;
                    case "redo":
                        Board.RedoMove();
                        break;
                    default:
                        // Transforms users (col, row) input into a move
                        try
                        {
                            string[] tokens = userInput.Split();
                            int col = int.Parse(tokens[0]);
                            int row = int.Parse(tokens[1]);
                            var move = (col, row);
                            return move;
                        }
                        catch
                        {
                            Console.WriteLine($"Entered input {userInput} is invalid. Please press Enter to try again.");
                            Console.ReadLine();
                            break;
                        }
                }
                // Return invalid output so while loop iterates again
                return (-1,-1);
            }
        }
    }
}