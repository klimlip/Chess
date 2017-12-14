using System.Linq;
using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс для паттерна Strategy (ConcreteStrategyA)
    /// стратегия для человека
    /// </summary>
    public class HumanStrategy: IPlayerStrategy
    {
        private static HumanStrategy instance;

        //----------- делаем класс одиночкой -----------
        public static HumanStrategy Instance { get { return instance = instance ?? new HumanStrategy(); } }

        private HumanStrategy()
        {
        }
        //----------------------------------

        public List<Move> PossibleMoves { get; private set; }
        public bool IsHuman { get { return true; } }

        /// <summary>
        /// метод для совершения хода
        /// </summary>
        /// <param name="possibleMoves"></param>
        public void DoMove(List<Move> possibleMoves)
        {
            this.PossibleMoves = possibleMoves;
        }

        /// <summary>
        /// метод окончания хода
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="newLocation"></param>
        public void FinishMove(Figure figure, Point newLocation)
        {
            var move = GetPossibleMove(figure, newLocation);
            
            if (move == null)
            {
                return;
            }

            Game.Instance.DoMove(move);
        }

        /// <summary>
        /// метод получения доступных ходов для данной шашки
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        private Move GetPossibleMove(Figure figure, Point location)
        {
            var move = PossibleMoves.FirstOrDefault(m => m.Figure.Equals(figure) && m.NewLocation == location);
            return move;
        }
    }
}
