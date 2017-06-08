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
                DrawBox(41, 3, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 3, 18, 4, '#');
            }
            if (selectedButton == 1)
            {
                DrawBox(41, 8, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 8, 18, 4, '#');
            }
            if (selectedButton == 2)
            {
                DrawBox(41, 13, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 13, 18, 4, '#');
            }
            if (selectedButton == 3)
            {
                DrawBox(41, 18, 18, 4, '#', consolecolor);
            }
            else
            {
                DrawBox(41, 18, 18, 4, '#');
            }
            Console.SetCursorPosition(0, 0);
        }

        public static void LoadCharacters(int position)
        {
            Console.Clear();
            var characters = GameService.loadedCharacters;
            int offset = 0;
            int counter = 0;
            if (characters is null || characters.Count <= 0)
            {
                DrawBox(40, 10, 20, 4, '@', ConsoleColor.Red);
                Console.SetCursorPosition(42, 12);
                Console.Write("No saved heroes!");
                Console.ReadKey();
            }
            else
            {
                foreach (var hero in characters)
                {
                    if (position == counter)
                    {
                        DrawBox(41, 2 + offset, 18, 4, '@', ConsoleColor.Blue);
                    }
                    else
                    {
                        DrawBox(41, 2 + offset, 18, 4, '@');
                    }
                    Console.SetCursorPosition(48, 4 + offset);
                    Console.Write(hero.Name);
                    counter++;
                    Console.WriteLine();
                    offset += 5;
                }

                ConsoleKeyInfo pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    var hero = characters[position];
                    GameService.currentCharacter = hero;
                    //TODO CALL MAP METHOD OR LEVEL
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    position--;
                    if (position < 0)
                    {
                        position = characters.Count - 1;
                    }
                    LoadCharacters(position);
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    if (position > characters.Count - 1)
                    {
                        position = 0;
                    }
                    LoadCharacters(position);
                }
                else if (pressedKey.Key == ConsoleKey.Delete)
                {
                    var hero = characters[position];
                    GameService.DeleteSavedCharacter(hero.Name);
                    position = 0;
                    LoadCharacters(position);
                }
                else
                {
                    LoadCharacters(position);
                }
            }
        }

        public static void ShowHighscores()
        {
            Console.Clear();
            var characters = GameService.loadedCharacters.OrderByDescending(h => h.HighScore);

            var offset = 0;

            foreach (var hero in characters)
            {
                DrawBox(41, 2 + offset, 18, 4, '@', ConsoleColor.Green);
                Console.SetCursorPosition(48, 4 + offset);
                Console.Write(hero.Name);
                Console.SetCursorPosition(48, 5 + offset);
                Console.Write(hero.HighScore);
                offset += 5;
            }

            Console.ReadKey();
        }

        public static void CreateNewCharacter()
        {
            Console.Clear();
            Console.CursorVisible = true;
            DrawBox(35, 10, 30, 10, '@');
            Console.SetCursorPosition(45, 12);
            Console.Write("HERO NAME:");
            Console.SetCursorPosition(36, 15);
            Console.Write(new string('_', 28));
            Console.SetCursorPosition(39, 17);
            Console.Write("Press enter to start!");
            Console.SetCursorPosition(37, 14);
            var name = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(name))
            {
                Console.SetCursorPosition(37, 14);
                name = Console.ReadLine().Trim();
            }
            Console.CursorVisible = false;
            GameService.CreateCharacter(name);
        }

        private static void DrawBox(int col, int row, int width, int hight, char ch, ConsoleColor consolecolor = ConsoleColor.White)
        {
            Console.ForegroundColor = consolecolor;

            Console.SetCursorPosition(col, row);
            Console.Write(new string(ch, width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col, row + i);
                Console.Write(ch);
            }
            Console.SetCursorPosition(col, row + hight);
            Console.Write(new string(ch, width));
            for (int i = 1; i < hight; i++)
            {
                Console.SetCursorPosition(col + width - 1, row + i);
                Console.Write(ch);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}