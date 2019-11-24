using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction dir;
        public Snake(Point tail, int length, Direction _dir)
        {
            dir = _dir;
            pList = new List<Point>();
            for(int i = 0; i < length; i += 1)
            {
                Point p = new Point(tail);
                p.Move(i, _dir);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);

            Point head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }

        private Point GetNextPoint()
        {
            Point nextPoint = new Point( pList.Last());
            nextPoint.Move(1, dir);
            return nextPoint;
        }

        public void HandleKey (ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (dir == Direction.RIGHT)
                    {
                        break;
                    }
                    dir = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    if (dir == Direction.LEFT)
                    {
                        break;
                    }
                    dir = Direction.RIGHT;
                    break;
                case ConsoleKey.UpArrow:
                    if (dir == Direction.DOWN)
                    {
                        break;
                    }
                    dir = Direction.UP;
                    break;
                case ConsoleKey.DownArrow:
                    if (dir == Direction.UP)
                    {
                        break;
                    }
                    dir = Direction.DOWN;
                    break;
            }
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                food.Draw();
                pList.Add(food);
                return true;
            }
            return false;
        }

        public bool IsHit (Walls walls)
        {
            int x = GetNextPoint().x;
            int y = GetNextPoint().y;
            int w = walls.GetWidth();
            int h = walls.GetHeight();
            if (x == 0 || x == w)
            {
                return true;
            }
            if (y == 0 || y == h)
            {
                return true;
            }
            return false;
        }

        public bool IsHit()
        {
            Point head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public int GetSpeed()
        {
            if (dir == Direction.DOWN || dir == Direction.UP)
            {
                return 200;
            }
            return 100;
        }
    }
}
