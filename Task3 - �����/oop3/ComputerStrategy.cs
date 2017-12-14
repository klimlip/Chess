using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace oop3
{
    /// <summary>
    /// класс для паттерна Strategy (ConcreteStrategyB)
    /// стратегия для компьютера
    /// </summary>
    public class ComputerStrategy: IPlayerStrategy
    {
        private readonly Random random;

        //----- делаем класс одиночкой -------------
        private static ComputerStrategy instance;

        public static ComputerStrategy Instance { get { return instance = instance ?? new ComputerStrategy(); } }

        private ComputerStrategy()
        {
            this.random = new Random();
        }
        //------------------------

        /// <summary>
        /// метод компьюютерного хода
        /// </summary>
        /// <param name="possibleMoves"></param>
        public void DoMove(List<Move> possibleMoves)
        {
            Thread.Sleep(500);

            var killingMoves = possibleMoves.Where(x => x.IsKillingMove).ToList(); //проверяем, может ли кого-то убить
            var move = GetRandomMove(killingMoves.Count > 0 ? killingMoves : possibleMoves);//есть кого убить ? выбираем доступные 
                                                                                            //ходы из "убийственных" : из простых
            Game.Instance.DoMove(move);// вызываем метод класса Game
        }

        /// <summary>
        /// метод для выбора рандомного хода компьютера
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        private Move GetRandomMove(List<Move> moves)
        {
            var ind = random.Next(moves.Count);
            return moves[ind];
        }
    }
}
