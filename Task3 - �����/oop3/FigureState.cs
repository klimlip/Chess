using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс для паттерна State, Context = Figure
    /// </summary>
    public abstract class FigureState
    {
        public abstract bool IsKing { get; }
        public abstract List<Move> GetPossibleMoves(Figure thisFigure, List<Figure> figures);
        public abstract Figure GetKilledFigure(Move move);

        /// <summary>
        /// метод проверки, можно ли убить фигуру
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="killingFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        protected bool CanKillFigure(Figure thisFigure, Figure killingFigure, List<Figure> figures)
        {
            var check = CalculationHelper.GetNextInThisDirection(thisFigure.Location, killingFigure.Location);
            var canKill = CalculationHelper.IsWithinInField(check)
                && !CalculationHelper.IfAnyFigureOnPoint(check, figures)
                && killingFigure.Player != thisFigure.Player;
            return canKill;
        }
    }
}
