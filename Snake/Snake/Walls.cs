using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        int width;
        int height;
        protected List<Figure> lineList;
        public Walls(int width, int height)
        {
            this.width = width;
            this.height = height;
            CreateLines();
        }
        private void CreateLines()
        {
            lineList.Add(new HorizontalLine(0, width, 0, '*'));
            lineList.Add(new HorizontalLine(0, width, height, '*'));
            lineList.Add(new VerticalLine(0, 0, height, '*'));
            lineList.Add(new VerticalLine(width, 0, height, '*'));
        }

        public void Draw()
        {
            foreach (Figure line in lineList)
            {
                line.Draw();
            }
        }
    }
}
