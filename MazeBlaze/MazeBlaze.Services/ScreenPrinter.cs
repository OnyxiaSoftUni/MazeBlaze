using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBlaze.Services
{
    public static class ScreenPrinter
    {
        public static void WelcomeScreen(int selectedButton = 0)
        {
            Console.Clear();
            Console.SetCursorPosition(46, 5);
            Console.Write("NEW GAME");

            Console.SetCursorPosition(46, 10);
            Console.Write("USE SAVE");

            Console.SetCursorPosition(47, 15);
            Console.Write("SCORES");

            Console.SetCursorPosition(48, 20);
            Console.Write("EXIT");

            var consolecolor = ConsoleColor.Blue;
            if (selectedButton == 0)
            {
                DrawBox(41, 3, 18, 4, consolecolor);
            }
            else
            {
                DrawBox(41, 3, 18, 4);
            }
            if (selectedButton == 1)
            {
                DrawBox(41, 8, 18, 4, consolecolor);
            }
            else
            {
                DrawBox(41, 8, 18, 4);
            }
            if (selectedButton == 2)
            {
                DrawBox(41, 13, 18, 4, consolecolor);
            }
            else
            {
                DrawBox(41, 13, 18, 4);
            }
            if (selectedButton == 3)
            {
                DrawBox(41, 18, 18, 4, consolecolor);
            }
            else
            {
                DrawBox(41, 18, 18, 4);
            }
            Console.SetCursorPosition(0, 0);
        }

        private static void DrawBox(int col, int row, int width, int hight, ConsoleColor consolecolor = ConsoleColor.White)
        {
            Console.ForegroundColor = consolecolor;

            Console.SetCursorPosition(col, row);
            Console.Write(new string('#', width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col, row + i);
                Console.Write('#');
            }
            Console.SetCursorPosition(col, row + hight);
            Console.Write(new string('#', width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col + width - 1, row + i);
                Console.Write('#');
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}