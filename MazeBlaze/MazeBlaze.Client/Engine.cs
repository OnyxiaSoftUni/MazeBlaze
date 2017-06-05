using MazeBlaze.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MazeBlaze.Client
{
    public class Engine
    {
        private static int currentPossition = 0;

        public static void Run()
        {
            //GameService.CreateDummySave(); //Use this to create a dummy test.
            InitializeData();
            ShowWelcomeScreen();
            ExecuteWelcomeScreenSelection(currentPossition);
        }

        private static void ExecuteWelcomeScreenSelection(int currentPossition)
        {
            switch (currentPossition)
            {
                case 0:
                    //TODO CREATE NEW CHARACTER SCREEN
                    break;

                case 1:
                    //TODO CREATE LOAD CHARACTER SCREEN
                    break;

                case 2:
                    //TODO CREATE HIGHSCORES SCREEN
                    break;

                case 3:
                    Console.Beep(4250, 300);
                    Environment.Exit(0);
                    break;
            }
        }

        private static void ShowWelcomeScreen()
        {
            ScreenPrinter.WelcomeScreen(currentPossition);
            bool isSelecting = true;
            while (isSelecting)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    Console.Beep(7000, 70);
                    currentPossition--;
                    if (currentPossition < 0)
                    {
                        currentPossition = 3;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    Console.Beep(7000, 70);
                    currentPossition++;
                    if (currentPossition > 3)
                    {
                        currentPossition = 0;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    isSelecting = false;
                    break;
                }

                ScreenPrinter.WelcomeScreen(currentPossition);
            }
        }

        private static void InitializeData()
        {
            try
            {
                GameService.LoadSavedData();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}