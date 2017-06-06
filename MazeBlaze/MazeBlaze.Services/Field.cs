using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBlaze.Services
{

    struct Position
    {
        public int X;
        public int Y;
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Field
    {
        public static void LevelBuild()
        {
            var directions = new Position[]
                {
                           new Position(0,1), //moving right
                           new Position( 0,-1), // moving left
                           new Position( 1,0), // moving down
                           new Position(-1,0), // moving up

                };

            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 60); // BUFFER SIZE PROBLEM
            List<Position> levelObsticle;
            Position obsticle;
            Obsticles(out levelObsticle, out obsticle);



            var movement = 0;


            var player = new Position { X = 0, Y = 0 };



            Console.SetCursorPosition(player.Y, player.X);
            Console.Write("&");


            foreach (var item in levelObsticle)
            {
                Console.SetCursorPosition(item.Y, item.X);
                Console.Write("#");
            }

            while (true)
            {
                var userDirection = Console.ReadKey();
                if (userDirection.Key == ConsoleKey.RightArrow)
                {
                    movement = 0;
                }
                if (userDirection.Key == ConsoleKey.LeftArrow)
                {
                    movement = 1;
                }
                if (userDirection.Key == ConsoleKey.DownArrow)
                {
                    movement = 2;
                }
                if (userDirection.Key == ConsoleKey.UpArrow)
                {
                    movement = 3;
                }



                Position currPosition = player;

                var nextDirection = directions[movement];
                var nextPosition = new Position
                    (currPosition.X + nextDirection.X, currPosition.Y + nextDirection.Y);

                if (nextPosition.X >= Console.BufferHeight || nextPosition.Y >= Console.BufferHeight ||
                    nextPosition.X < 0 || nextPosition.Y < 0)
                {
                    continue;
                }



                else if (nextPosition.X == obsticle.X && nextPosition.Y == obsticle.Y ||
                    nextPosition.X == obsticle.X && nextPosition.Y == obsticle.Y)

                {
                    Console.Write("Game Over"); // TODO FIX OBSTICLES 
                    Console.WriteLine();
                    return;
                }
                else
                {
                    player = nextPosition;

                }



                Console.Clear();
                foreach (var obstic in levelObsticle)
                {
                    Console.SetCursorPosition(obstic.Y, obstic.X);
                    Console.Write("#");
                }



                Console.SetCursorPosition(player.Y, player.X);
                Console.Write("&");


            }

        }

        private static void Obsticles(out List<Position> levelObsticle, out Position obsticle)
        {
            levelObsticle = new List<Position>();   // MAKE A WALL OF OBSTICLES
            obsticle = new Position { X = 0, Y = 0 };
            var obsticle2 = new Position { X = 0, Y = 0 };


            for (int i = 10; i < 30; i++)
            {

                obsticle = new Position { X = 5, Y = i };
                obsticle2 = new Position { X = 7, Y = i };
                levelObsticle.Add(obsticle);
                levelObsticle.Add(obsticle2);
            }
        }
    }
}

