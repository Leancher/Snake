using System;
using System.Threading;

namespace Snake
{
    class Program
    {


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

                Thread.Sleep(snake.GetSpeed());
            }
            WriteGameOver();
            Console.ReadLine();
        }
        static void InitWindow()
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;
        }
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("===========================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset, yOffset++);
            yOffset++;
            WriteText("      Автор: Leancher     ", xOffset, yOffset++);
            WriteText("===========================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}

