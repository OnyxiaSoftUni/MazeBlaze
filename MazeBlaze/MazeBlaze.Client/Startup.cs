using MazeBlaze.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBlaze.Client
{
    class Startup
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Engine.Run();
            Console.Clear();
            Field.LevelBuild();
        }
    }
}