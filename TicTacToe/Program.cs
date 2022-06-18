using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    static class Program
    {
        // Creates global public static variables
        public static int col = -1;
        public static int row = -1;
        public static char player = 'X';
        public static List<List<List<int>>> History = new List<List<List<int>>>(10);
        public static int movesPlayed = 0;
        public static void Main()
        {
            // Initialises the game board
            for (int i = 0; i < 10; i++)
            {
                var b = new List<List<int>> {
                new List<int>{ },
                new List<int>{ },
                new List<int>{ }
                };
                Board.CreateBoard(b);
                History.Add(b);
            }

            // The game will play until there is a winner/loser/draw/restarted
            while (true)
            {
                // Select Opponent
                string opponentType = Menu.SelectOpponentType();
                // Validation check for user input
                if (opponentType != "C" && opponentType != "H")
                {
                    continue;
                }
                // 2 Player Human vs Human Game
                else if (opponentType == "H")
                {
                    while (true)
                    {
                        var ShouldGameEnd = HumanPlayerTurn();
                        if (ShouldGameEnd)
                        {
                            break;
                        }
                    }
                    Board.PrintBoard(History[movesPlayed]);
                    Console.ReadLine();
                    Environment.Exit(1);
                }
                // Human vs Computer Game
                else
                {
                    while (true)
                    {
                        // Select Computer opponent difficulty
                        string computerDifficulty = Menu.SelectComputerDifficulty();
                        // Validation check for user input
                        if (computerDifficulty != "E" && computerDifficulty != "H")
                        {
                            continue;
                        }
                        // Computer Easy Difficulty Game
                        else if (computerDifficulty == "E")
                        {
                            while (true)
                            {
                                var ShouldGameEnd = HumanPlayerTurn();
                                if (ShouldGameEnd)
                                {
                                    break;
                                }

                                ShouldGameEnd = ComputerPlayerTurn();
                                if (ShouldGameEnd)
                                {
                                    break;
                                }
                            }
                            Board.PrintBoard(History[movesPlayed]);
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                        // Computer Hard Difficulty Game
                        else
                        {
                            // Hard computer AI game goes here
                            // Currently Alpha-Beta Algorithm is not implemented
                            // Just using Computer Easy difficulty as a place-holder
                            while (true)
                            {
                                var ShouldGameEnd = HumanPlayerTurn();
                                if (ShouldGameEnd)
                                {
                                    break;
                                }

                                ShouldGameEnd = ComputerPlayerTurn();
                                if (ShouldGameEnd)
                                {
                                    break;
                                }
                            }
                            Board.PrintBoard(History[movesPlayed]);
                            Console.ReadLine();
                            Environment.Exit(1);
                        }
                    }
                }
            }

            // To reset game, just reset all variables to inital values and then
            // add everything in a big loop that would redo all the steps

        }

        // Modifies Clone() method to allow the saving of nested lists for this application
        public static IList<T> Clone<T>(this IList<T> list)
        {
            return new List<T>(list.Select(q =>
            
                (T)(q is ICloneable w ? w.Clone() : q)
            
            ).ToList());
        }


        // Method that handles human user input and turn
        private static bool HumanPlayerTurn()
        {
            while (!Game.CheckValidMove(player, row, col))
            {
                var move = Player.UserInputValidation(player);
                col = move.Col;
                row = move.Row;
            }

            History[movesPlayed + 1] = History[movesPlayed].Select(q => new List<int> { q[0],q[1],q[2] }).ToList();

            Player.MakeMove(player, History[movesPlayed + 1], row, col);

            movesPlayed++;

            if (Game.CheckWinner(player, History[movesPlayed]))
            {
                Console.WriteLine(player + " has won the game!");
                return true;
            }

            if (Game.CheckDraw())
            {
                Console.WriteLine("DRAW");
                return true;
            }


            player = Board.ChangeTurn(player);

            col = -1;
            row = -1;

            return false;
        }

        // Method that handles computer turn
        private static bool ComputerPlayerTurn()
        {
            var computerMove = Computer.RandomMove(History[movesPlayed]);
            col = computerMove.col;
            row = computerMove.row;

            History[movesPlayed + 1] = History[movesPlayed].Select(q => new List<int> { q[0], q[1], q[2] }).ToList();

            Player.MakeMove(player, History[movesPlayed + 1], row, col);

            movesPlayed++;

            if (Game.CheckWinner(player, History[movesPlayed]))
            {
                Console.WriteLine(player + " has won the game!");
                return true;
            }

            if (Game.CheckDraw())
            {
                Console.WriteLine("DRAW");
                return true;
            }


            player = Board.ChangeTurn(player);

            col = -1;
            row = -1;

            return false;
        }

    }
}