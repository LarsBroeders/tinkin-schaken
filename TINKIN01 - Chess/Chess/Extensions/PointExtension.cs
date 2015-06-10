using System;
using System.Collections.Generic;
using System.Drawing;

namespace TINKIN01.Chess.Extensions
{
    public static class PointExtension
    {
        /// <summary>
        /// Determins wether a move is in a line
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Point> Between(this Point start, Point end)
        {
            var deltaX = Math.Abs(start.X - end.X);
            var deltaY = Math.Abs(start.Y - end.Y);

            var stepX = 0;
            if (start.X - end.X < 0)
                stepX = 1;
            else if (start.X - end.X > 0)
                stepX = -1;

            var stepY = 0;
            if (start.Y - end.Y < 0)
                stepY = 1;
            else if (start.Y - end.Y > 0)
                stepY = -1;

            var step = new Point(stepX, stepY);

            for (int i = 1; i < Math.Max(deltaX, deltaY); i++)
            {
                yield return new Point(start.X + step.X * i, start.Y + step.Y * i);
            }  
        }
    }
}
