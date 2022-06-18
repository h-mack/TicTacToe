using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IMenu
    {
        public static void DisplayMenu() { }
        public static void DisplayGameRules() { }
        public static void SelectOpponentType() { }
        public static void SelectComputerDifficulty() { }
    }
}
