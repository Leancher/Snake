using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;

            HorizontalLine upLine = new HorizontalLine(0, 70, 0, '*');
            HorizontalLine downLine = new HorizontalLine(0, 70, 24, '*');
            VerticalLine leftLine = new VerticalLine(0, 0, 24, '*');
            VerticalLine rightLine = new VerticalLine(70, 0, 24, '*');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(4, 6, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreater foodCreater = new FoodCreater(70, 24, '$');
            Point food = foodCreater.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreater.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                
                Thread.Sleep(100);
            }
        }
    }
}
