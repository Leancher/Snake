using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void InitWindow()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;
        }

        static void Main(string[] args)
        {
            InitWindow();

            Walls walls = new Walls(70, 24);
            walls.Draw();

            Point p = new Point(4, 6, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreater foodCreater = new FoodCreater(70, 24, '$');
            Point food = foodCreater.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.IsHit(walls))
                {
                    break;
                }
                if (snake.IsHit())
                {
                    break;
                }
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
                if (snake.Dir == Direction.DOWN || snake.Dir == Direction.UP)
                {
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);
            }
        }
    }
}
