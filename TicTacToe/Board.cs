using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TicTacToe
{
    class Board : IBoard, ICloneable
    {
        // Didn't feel the need to leave comments on what each method does
        // as their names should speak for themselves

        public static void CreateBoard(List<List<int>> board)
        {
            for (int rows = 0; rows < 3; rows++)
            {
                board[rows] = new List<int> { ' ', ' ', ' ' };
            }
        }

        public static void PrintBoard(List<List<int>> board)
        {
            Console.WriteLine("    0   1   2  ");
            Console.WriteLine("   -----------");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " | ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(Convert.ToChar(board[row][col]));
                    Console.Write(" | ");
                }
                Console.WriteLine("\n   ---+---+---");
            }
            Console.SetCursorPosition(0, 7);
            Console.Write("   -----------\n");
            Console.WriteLine("Turn: " + Program.movesPlayed);
        }

        public static char ChangeTurn(char currentPlayer)
        {
            return (currentPlayer == 'X') ? 'O' : 'X';
        }

        // Serializes an object list into an xml file
        public static void SaveGame<T>(T obj, string fileName)
        {
            if (obj == null) { return; }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    serializer.Serialize(writer, obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your save request has encountered an error \n {0}", ex);
            }
        }

        // Deserializes an xml file into an object list
        public static T LoadGame<T>(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void UndoMove()
        {
            Program.movesPlayed--;
            Program.player = ChangeTurn(Program.player);
        }

        public static void RedoMove()
        {
            Program.movesPlayed++;
            Program.player = ChangeTurn(Program.player);
        }

        public static void RestartGame()
        {
            Console.Clear();
            Program.History = Board.LoadGame<List<List<List<int>>>>("blankGame.xml");
        }

        // This was going to be used to clone game boards for the alpha-beta algorithm
        // However it is not yet implemented and thus currently unused
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}