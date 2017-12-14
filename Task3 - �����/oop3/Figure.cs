using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс фигуры
    /// </summary>
    public class Figure
    {
        private FigureState state;

        public int X { get; set; }
        public int Y { get; set; }
        public Player Player { get; private set; }
        public bool IsFirstPlayer { get; private set; }

        public Point Location { get { return new Point(X, Y); } }
        public bool IsKing { get { return state.IsKing; } }

        /// <summary>
        /// скрытый конструктор
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="player"></param>
        /// <param name="isFirstPlayer"></param>
        /// <param name="state"></param>
        private Figure(int x, int y, Player player, bool isFirstPlayer, FigureState state)
        {
            this.X = x;
            this.Y = y;
            this.Player = player;
            this.IsFirstPlayer = isFirstPlayer;
            this.state = state;
        }

        /// <summary>
        /// метод создания простой шашки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="player"></param>
        /// <param name="isFirstPlayer"></param>
        /// <returns></returns>
        public static Figure CreateSimple(int x, int y, Player player, bool isFirstPlayer)
        {
            var figure = new Figure(x, y, player, isFirstPlayer, SimpleFigureState.Instance);
            return figure;
        }

        /// <summary>
        /// метод создания дамки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="player"></param>
        /// <param name="isFirstPlayer"></param>
        /// <returns></returns>
        public static Figure CreateKing(int x, int y, Player player, bool isFirstPlayer)
        {
            var figure = new Figure(x, y, player, isFirstPlayer, KingFigureState.Instance);
            return figure;
        }

        /// <summary>
        /// метод для получения возможных ходов для выбранной шашки
        /// </summary>
        /// <param name="figures"></param>
        /// <returns></returns>
        public List<Move> GetPossibleMoves(List<Figure> figures)
        {
            return state.GetPossibleMoves(this, figures);
        }

        /// <summary>
        /// смена на дамку
        /// </summary>
        public void ChangeToKing()
        {
            this.state = KingFigureState.Instance;
        }

        /// <summary>
        /// метод проверки на эквивалентность
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var figure = obj as Figure;

            if (figure == null)
            {
                return false;
            }

            return figure.Player == Player && figure.Location == Location && figure.state.IsKing == state.IsKing;
        }

        /// <summary>
        /// метод получения убитой фигуры
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public Figure GetKilledFigure(Move move)
        {
            return state.GetKilledFigure(move);
        }
    }
}
