using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс игрового поля
    /// </summary>
    public class GameField: IGameFieldNotificationPublisher
    {
        private List<Figure> figures;
        private List<IGameFieldNotificationObserver> observers;
        private readonly Player player1;
        private readonly Player player2;

        public List<Figure> Figures { get { return figures; } }

        /// <summary>
        /// получение инфы о фигурах
        /// </summary>
        public List<FigureInfo> FiguresInfo
        {
            get 
            {
                return figures
                .Select(x => new FigureInfo { X = x.X, Y = x.Y, IsFirstPlayer = x.Player == player1, IsKing = x.IsKing })
                .ToList();
            }
        }

        /// <summary>
        /// расстановка фигур на поле для новой игры
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public GameField(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            var figures = new List<Figure>();
            this.observers = new List<IGameFieldNotificationObserver>();

            for (int i = 1; i <= 4; i++)
            {
                figures.Add(Figure.CreateSimple(i * 2, 1, player1, true ));
                figures.Add(Figure.CreateSimple(i * 2 - 1, 2, player1, true ));
                figures.Add(Figure.CreateSimple(i * 2, 3, player1, true ));

                figures.Add(Figure.CreateSimple(i * 2 - 1, 6, player2, false ));
                figures.Add(Figure.CreateSimple(i * 2, 7, player2, false ));
                figures.Add(Figure.CreateSimple(i * 2 - 1, 8, player2, false ));
            }

            this.figures = figures;
        }

        /// <summary>
        /// расстановка фигур на поле для сохраненной игры
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="figuresInfo"></param>
        public GameField(Player player1, Player player2, List<FigureInfo> figuresInfo)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.observers = new List<IGameFieldNotificationObserver>();

            var figures = figuresInfo
                .Select(x => x.IsKing ? Figure.CreateKing(x.X, x.Y, x.IsFirstPlayer ? player1 : player2, x.IsFirstPlayer)
                                      : Figure.CreateSimple(x.X, x.Y, x.IsFirstPlayer ? player1 : player2, x.IsFirstPlayer))
                .ToList();
            this.figures = figures;
        }

        /// <summary>
        /// метод хода
        /// </summary>
        /// <param name="move"></param>
        public void DoMove(Move move)
        {
            var figure = move.Figure;
            var distPoint = move.NewLocation;//куда ходим
            var deltaPoint = CalculationHelper.GetDeltaPoint(figure.X, figure.Y, distPoint);//расстояние
            var realFigure = figures.FirstOrDefault(x => x.X == figure.X && x.Y == figure.Y);//есть ли вообще на данной клетке фигура

            if (realFigure == null || !this.CheckDistansePoint(distPoint) || !this.CheckDeltaPoint(deltaPoint))
            {
                throw new ArgumentException();
            }

            this.KillFigure(move);//если убили фигуру, удаляем ее

            realFigure.X = distPoint.X;
            realFigure.Y = distPoint.Y;

            var isFirstPlayer = realFigure.Player == player1;
            var needChangeToKing = (isFirstPlayer ? realFigure.Y == 8 : realFigure.Y == 1) && !realFigure.IsKing;

            if (needChangeToKing)
            {
                realFigure.ChangeToKing();
            }

            this.Notify();
        }

        /// <summary>
        /// метод паттерна Observer, добавление наблюдателей
        /// </summary>
        /// <param name="observers"></param>
        public void Attach(params IGameFieldNotificationObserver[] observers)
        {
            this.observers.AddRange(observers);
            this.Notify();
        }

        /// <summary>
        /// метод паттерна Observer, действие для наблюдателей
        /// </summary>
        public void Notify()
        {
            this.observers.ForEach(x => x.Update());
        }

        /// <summary>
        /// метод удаления убитой фигуры
        /// </summary>
        /// <param name="move"></param>
        public void KillFigure(Move move)
        {
            if (!move.IsKillingMove)
            {
                return;
            }

            var killedFigure = move.Figure.GetKilledFigure(move);

            if (killedFigure == null)
            {
                throw new ArgumentException();
            }

            this.figures.Remove(killedFigure);
        }

        /// <summary>
        /// метод проверки корректности выбранной клетки
        /// </summary>
        /// <param name="distPoint"></param>
        /// <returns></returns>
        private bool CheckDistansePoint(Point distPoint)
        {
            var x = distPoint.X;
            var y = distPoint.Y;
            var correct = x > 0 && x <= 8 && y > 0 && y <= 8;
            return correct;
        }

        /// <summary>
        /// метод проверки корректности выбранной дистанции
        /// </summary>
        /// <param name="deltaPoint"></param>
        /// <returns></returns>
        private bool CheckDeltaPoint(Point deltaPoint)
        {
            var absX = Math.Abs(deltaPoint.X);
            var absY = Math.Abs(deltaPoint.Y);
            var correct = absX == absY;
            return correct;
        }

        /// <summary>
        /// метод получения списка всех шашек данного игрока
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<Figure> GetPlayerFigures(Player player)
        {
            var playerFigures = figures.Where(x => x.Player == player).ToList();
            return playerFigures;
        }
    }
}
