using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс игрока
    /// </summary>
    public class Player
    {
        private IPlayerStrategy strategy;

        public bool IsHuman { get; private set; }

        //скрываем конструктор
        private Player()
        {
        }

        /// <summary>
        /// метод создания экземпляра игрока-компьютера
        /// </summary>
        /// <returns></returns>
        public static Player CreateComputerPlayer()
        {
            var player = new Player { IsHuman = false };
            player.strategy = ComputerStrategy.Instance;
            return player;
        }

        /// <summary>
        /// метод создания игрока-человека
        /// </summary>
        /// <returns></returns>
        public static Player CreateHumanPlayer()
        {
            var player = new Player { IsHuman = true };
            player.strategy = HumanStrategy.Instance;
            return player;
        }

        /// <summary>
        /// метод совершения хода
        /// </summary>
        /// <param name="possibleMoves"></param>
        public void DoMove(List<Move> possibleMoves)
        {
            this.strategy.DoMove(possibleMoves);
        }

        /// <summary>
        /// метод окончания хода
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="newLocation"></param>
        public void FinishMove(Figure figure, Point newLocation)
        {
            var humanStrategy = strategy as HumanStrategy;

            if (humanStrategy != null)
            {
                humanStrategy.FinishMove(figure, newLocation);
            }

        }
    }
}
