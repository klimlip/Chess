using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace oop3
{
    /// <summary>
    /// класс для паттерна State (ConcreteStateB)
    /// состояние "дамка"
    /// </summary>
    public class KingFigureState: FigureState
    {
        private static KingFigureState instance;

        //-------------------- делаем класс одиночкой -------------
        public static KingFigureState Instance { get { return instance = instance ?? new KingFigureState(); } }

        private KingFigureState()
        { }
        //----------------------------------

        public override bool IsKing
        {
            get { return true; }
        }

        /// <summary>
        /// метод получения доступных ходов для данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        public override List<Move> GetPossibleMoves(Figure thisFigure, List<Figure> figures)
        {
            var enemies = this.GetNearestEnemyFigures(thisFigure, figures);//враги

            List<Move> moves = null;

            if (enemies != null && enemies.Count > 0)//если есть рядом враги, выбираем "убийственные" ходы
            {
                moves = this.GetKillingMoves(thisFigure, figures, enemies);
            }

            if (moves == null || moves.Count == 0)//если "убийственных" нет, выбираем простые
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
            var dX = deltaPoint.X > 0 ? 1 : -1;
            var dY = deltaPoint.Y > 0 ? 1 : -1;
            var currentX = figure.X + dX;
            var currentY = figure.Y + dY;
            Figure killingFigure = null;

            while (currentX != move.NewLocation.X || currentY != move.NewLocation.Y)
            {
                killingFigure = figures.FirstOrDefault(f => f.X == currentX && f.Y == currentY && f.Player != figure.Player);
                
                if (killingFigure != null)
                {
                    break;
                }

                currentX += dX;
                currentY += dY;
            }
            
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
                    var newMoves = this.GetKillingMove(thisFigure, enemy, figures).Select(x => new Move(x, true, thisFigure)).ToList();
                    moves.AddRange(newMoves);
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
            var moves = new List<Move>();
            var deltas = new[] { new Point(1, 1), new Point(1, -1), new Point(-1, 1), new Point(-1, -1) };

            foreach (var delta in deltas)
            {
                var current = new Point(thisFigure.Location.X + delta.X, thisFigure.Location.Y + delta.Y);
                while (CalculationHelper.IsWithinInField(current) && !CalculationHelper.IfAnyFigureOnPoint(current, figures))
                {
                    var move = new Move(current, false, thisFigure);
                    moves.Add(move);
                    current.X += delta.X;
                    current.Y += delta.Y;
                }
            }
            return moves;
        }

        /// <summary>
        /// метод получения списка вражеских шашек относительно данной шашки
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        private List<Figure> GetNearestEnemyFigures(Figure thisFigure, List<Figure> figures)
        {
            return this.GetNearestEnemyFiguresByPoint(thisFigure, thisFigure.Location, figures);
        }

        /// <summary>
        /// метод получения списка вражеских шашек
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        private List<Figure> GetNearestEnemyFiguresByPoint(Figure thisFigure, Point location, List<Figure> figures)
        {
            var enemies = new List<Figure>();
            var deltas = new[] { new Point(1, 1), new Point(1, -1), new Point(-1, 1), new Point(-1, -1) };//направления

            foreach (var delta in deltas)
            {
                var current = new Point(location.X + delta.X, location.Y + delta.Y);//следущая для проверки клетка
                while (CalculationHelper.IsWithinInField(current))//пока в пределах поля, ищем ближайшего врага по каждому направлению
                {
                    var figure = CalculationHelper.FirstFigureOnPointOrDefault(current, figures);

                    if (figure != null)
                    {
                        if (figure.Player != thisFigure.Player)
                        {
                            enemies.Add(figure);
                        }

                        break;
                    }

                    current.X += delta.X;
                    current.Y += delta.Y;
                }
            }

            return enemies;
        }

        /// <summary>
        /// метод определения "убийственных ходов"
        /// </summary>
        /// <param name="thisFigure"></param>
        /// <param name="enemy"></param>
        /// <param name="figures"></param>
        /// <returns></returns>
        private List<Point> GetKillingMove(Figure thisFigure, Figure enemy, List<Figure> figures)
        {
            var current = CalculationHelper.GetNextInThisDirection(thisFigure.Location, enemy.Location);
            var prev = current;
            var killingMoves = new List<Point>();
            var nonKillingMoves = new List<Point>();

            while (CalculationHelper.IsWithinInField(current) && !CalculationHelper.IfAnyFigureOnPoint(current, figures))
            {
                var enemies = this.GetNearestEnemyFiguresByPoint(thisFigure, current, figures).ToList();//поиск врагов
                var killingEnemy = enemies.FirstOrDefault(f => this.CanKillFigure(thisFigure, f, figures));//выбираем, кого можно убить

                if (killingEnemy != null)
                {
                    killingMoves.Add(current);
                }
                else
                {
                    nonKillingMoves.Add(current);
                }

                prev = current;
                current = CalculationHelper.GetNextInThisDirection(thisFigure.Location, current);
            }

            return killingMoves.Count > 0 ? killingMoves : nonKillingMoves;
        }
    }
}
