using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IBoard
    {
        public static void CreateBoard() { }
        public static void PrintBoard() { }
        public static void ChangeTurn() { }
        public static void UndoMove() { }
        public static void RedoMove() { }
        public static void SaveGame() { }
        public static void LoadGame() { }
        public static void RestartGame() { }
    }
}
