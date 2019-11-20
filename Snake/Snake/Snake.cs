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
    }
}
