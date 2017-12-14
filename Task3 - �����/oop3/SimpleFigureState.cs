using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace oop3
{
    /// <summary>
    /// класс для паттерна State (ConcreteStateA)
    /// состояние "простая шашка"
    /// </summary>
    public class SimpleFigureState: FigureState
    {
        private static SimpleFigureState instance;

        public static SimpleFigureState Instance { get { return instance = instance ?? new SimpleFigureState(); } }

        private SimpleFigureState()
        { }

        public override bool IsKing
        {
            get { return false; }
        }

        /// <summary>
        /// метод получения доступных ходов для данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        public override List<Move> GetPossibleMoves(Figure thisFigure, List<Figure> figures)
        {
            var enemies = this.GetNearestEnemyFigures(thisFigure, figures);

            List<Move> moves = null;

            if (enemies != null && enemies.Count > 0)
            {
                moves = this.GetKillingMoves(thisFigure, figures, enemies);
            }

            if (moves == null || moves.Count == 0)
            {
                moves = this.GetSimpleMoves(thisFigure, figures);
            }

            return moves;
        }

        /// <summary>
        /// метод определения убитой шашки
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override Figure GetKilledFigure(Move move)
        {
            var figure = move.Figure;
            var game = Game.Instance;
            var figures = game.GetPlayerFigures(game.OtherPlayer);
            var deltaPoint = CalculationHelper.GetDeltaPoint(figure.Location, move.NewLocation);
            var killingX = figure.X + (deltaPoint.X > 0 ? 1 : -1);
            var killingY = figure.Y + (deltaPoint.Y > 0 ? 1 : -1);
            var killingFigure = figures.FirstOrDefault(f => f.X == killingX && f.Y == killingY && f.Player != figure.Player);
            return killingFigure;
        }

        /// <summary>
        /// метод получения списка доступных "убийственных" ходов для данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <param name="enemies"></param>
        /// <returns></returns>
        private List<Move> GetKillingMoves(Figure thisFigure, List<Figure> figures, List<Figure> enemies)
        {
            var moves = new List<Move>();

            foreach (var enemy in enemies)
            {
                var canKill = this.CanKillFigure(thisFigure, enemy, figures);

                if (canKill)
                {
                    var newLocation = CalculationHelper.GetNextInThisDirection(thisFigure.Location, enemy.Location);
                    var move = new Move(newLocation, true, thisFigure);
                    moves.Add(move);
                }
            }

            return moves;
        }

        /// <summary>
        /// метод получения обычных доступных ходов для данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        private List<Move> GetSimpleMoves(Figure thisFigure, List<Figure> figures)
        {
            var dY = thisFigure.IsFirstPlayer ? 1 : -1;
            var points = new[] { new Point(thisFigure.X + 1, thisFigure.Y + dY), new Point(thisFigure.X - 1, thisFigure.Y + dY) };
            var empty = points
                .Where(x => !CalculationHelper.IfAnyFigureOnPoint(x, figures) && CalculationHelper.IsWithinInField(x))
                .Select(x => new Move(x, false, thisFigure))
                .ToList();
            return empty;
        }

        /// <summary>
        /// метод получения списка ближайших врагов для данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        private List<Figure> GetNearestEnemyFigures(Figure thisFigure, List<Figure> figures)
        {
            var nearestFigures = figures.Where(x => CheckIfNearestEnemy(thisFigure, x)).ToList();
            return nearestFigures;
        }

        /// <summary>
        /// метод проверки, что рядом враг
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figure"></param>
        /// <returns></returns>
        private bool CheckIfNearestEnemy(Figure thisFigure, Figure figure)
        {
            var isEnemy =
                (Math.Abs(figure.X - thisFigure.X) == 1) &&
                (Math.Abs(figure.Y - thisFigure.Y) == 1) &&
                thisFigure.Player != figure.Player;
            return isEnemy;
        }
    }
}
