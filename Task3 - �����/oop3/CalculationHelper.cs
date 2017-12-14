using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace oop3
{
    /// <summary>
    /// класс для вспомогательных рассчетов
    /// </summary>
    public static class CalculationHelper
    {
        /// <summary>
        /// переопределенный метод GetNextInThisDirection
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Point GetNextInThisDirection(Point src, Point dir)
        {
            return GetNextInThisDirection(src.X, src.Y, dir.X, dir.Y);
        }

        /// <summary>
        /// метод для получения координат следующей выбранной клетки
        /// </summary>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="dirX"></param>
        /// <param name="dirY"></param>
        /// <returns></returns>
        public static Point GetNextInThisDirection(int srcX, int srcY, int dirX, int dirY)
        {
            var dX = dirX - srcX > 0 ? 1 : -1;
            var dY = dirY - srcY > 0 ? 1 : -1;
            return new Point(dirX + dX, dirY + dY);
        }

        /// <summary>
        /// метод для проверки, есть ли на данной клетке фигура
        /// </summary>
        /// <param name="point"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        public static bool IfAnyFigureOnPoint(Point point, List<Figure> figures)
        {
            var result = figures.Any(f => f.X == point.X && f.Y == point.Y);
            return result;
        }

        /// <summary>
        /// метод для получения фигуры, стоящей на данной клетке
        /// </summary>
        /// <param name="point"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        public static Figure FirstFigureOnPointOrDefault(Point point, List<Figure> figures)
        {
            var result = figures.FirstOrDefault(f => f.X == point.X && f.Y == point.Y);
            return result;
        }

        /// <summary>
        /// метод для проверки, что координата не выходит за игровое поле
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsWithinInField(Point point)
        {
            return point.X >= 1 && point.X <= 8 && point.Y >= 1 && point.Y <= 8;
        }

        /// <summary>
        /// метод GetDeltaPoint
        /// </summary>
        /// <param name="srcPoint"></param>
        /// <param name="distPoint"></param>
        /// <returns></returns>
        public static Point GetDeltaPoint(Point srcPoint, Point distPoint)
        {
            return GetDeltaPoint(srcPoint.X, srcPoint.Y, distPoint);
        }

        /// <summary>
        /// метод для получения расстояния между выбранными клетками
        /// </summary>
        /// <param name="srcX"></param>
        /// <param name="srcY"></param>
        /// <param name="distPoint"></param>
        /// <returns></returns>
        public static Point GetDeltaPoint(int srcX, int srcY, Point distPoint)
        {
            var dX = distPoint.X - srcX;
            var dY = distPoint.Y - srcY;
            return new Point(dX, dY);
        }
    }
}
