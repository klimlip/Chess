using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace oop3
{
    /// <summary>
    /// основной класс игры
    /// </summary>
    public class Game
    {
        private readonly GameField gameField;
        private readonly Visualisator visualisator;

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public Player OtherPlayer { get { return CurrentPlayer == Player1 ? Player2 : Player1; } }

        public static Game Instance { get; private set; } //делаем класс одиночкой

        /// <summary>
        /// создание новой игры
        /// </summary>
        /// <param name="getGraphicsFunc"></param>
        /// <param name="isFirstPlayerHuman"></param>
        /// <param name="isSecondPlayerHuman"></param>
        private Game(Func<Graphics> getGraphicsFunc, bool isFirstPlayerHuman, bool isSecondPlayerHuman)
        {
            this.Player1 = isFirstPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            this.Player2 = isSecondPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            this.CurrentPlayer = Player1;

            this.gameField = new GameField(Player1, Player2);
            Visualisator.CreateInstance(getGraphicsFunc, gameField);
            this.visualisator = Visualisator.Instance;
            this.gameField.Attach(this.visualisator);
        }

        /// <summary>
        /// загрузка сохраненной игры
        /// </summary>
        /// <param name="path"></param>
        /// <param name="getGraphicsFunc"></param>
        private Game(string path, Func<Graphics> getGraphicsFunc)
        {
            var serializationInfo = this.Deserialize(path);
            this.Player1 = serializationInfo.IsFirstPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            this.Player2 = serializationInfo.IsSecondPlayerHuman ? Player.CreateHumanPlayer() : Player.CreateComputerPlayer();
            this.CurrentPlayer = serializationInfo.IsFirstPlayerMove ? Player1 : Player2;

            this.gameField = new GameField(Player1, Player2, serializationInfo.Figures);
            Visualisator.CreateInstance(getGraphicsFunc, gameField);
            this.visualisator = Visualisator.Instance;
            this.gameField.Attach(this.visualisator);
        }

        /// <summary>
        /// метод создания экземпляра класса Game новой игры
        /// </summary>
        /// <param name="getGraphicsFunc"></param>
        /// <param name="isFirstPlayerHuman"></param>
        /// <param name="isSecondPlayerHuman"></param>
        public static void CreateInstance(Func<Graphics> getGraphicsFunc, bool isFirstPlayerHuman, bool isSecondPlayerHuman)
        {
            Instance = new Game(getGraphicsFunc, isFirstPlayerHuman, isSecondPlayerHuman);
            Instance.Start();
        }

        /// <summary>
        /// метод создания экземпляра класса Game сохрвненной игры
        /// </summary>
        /// <param name="path"></param>
        /// <param name="getGraphicsFunc"></param>
        public static void CreateInstance(string path, Func<Graphics> getGraphicsFunc)
        {
            Instance = new Game(path, getGraphicsFunc);
            Instance.Start();
        }

        /// <summary>
        /// метод запуска игры
        /// </summary>
        public void Start()
        {
            var moves = GetPossibleMoves(CurrentPlayer);
            CurrentPlayer.DoMove(moves);
        }

        /// <summary>
        /// метод хода
        /// </summary>
        /// <param name="move"></param>
        public void DoMove(Move move)
        {
            this.gameField.DoMove(move);

            var killingMoves = move.Figure.GetPossibleMoves(this.gameField.Figures).Where(x => x.IsKillingMove).ToList();
            var moves = killingMoves;//ищем, если еще "убийственные" ходы

            if (!move.IsKillingMove || killingMoves.Count == 0)//если нет, меняем игрока
            {
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
                moves = GetPossibleMoves(CurrentPlayer);
            }

            if (moves.Count == 0)//если у кого-то больше нет ходов, показываем, кто победил
            {
                this.ShowVictory(CurrentPlayer == Player2 ? "The first player" : "The second player");
                return;
            }

            CurrentPlayer.DoMove(moves);
        }

        /// <summary>
        /// метод получения списка фигур данного игрока
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public List<Figure> GetPlayerFigures(Player player)
        {
            return this.gameField.GetPlayerFigures(player);
        }

        /// <summary>
        /// метод сохранения
        /// </summary>
        /// <param name="name"></param>
        public void Serialize(string name) 
        {
            var info = GetSerializationInfo();
            SerializationHelper.Serialize(name, info);
        }

        /// <summary>
        /// метод получения доступных ходов для всех шашек данного игрока
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private List<Move> GetPossibleMoves(Player player)
        {
            var moves = this.gameField
                    .Figures.Where(x => x.Player == CurrentPlayer)
                    .SelectMany(y => y.GetPossibleMoves(this.gameField.Figures))
                    .ToList();
            var killingMoves = moves.Where(m => m.IsKillingMove).ToList();
            return killingMoves.Count > 0 ? killingMoves : moves;
        }

        /// <summary>
        /// метод загрузки
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private SerializationInfo Deserialize(string path)
        {
            return SerializationHelper.Deserialize(path);
        }

        /// <summary>
        /// метод получения инфы о зохраненной игре
        /// </summary>
        /// <returns></returns>
        private SerializationInfo GetSerializationInfo()
        {
            return new SerializationInfo
            {
                Figures = gameField.FiguresInfo,
                IsFirstPlayerMove = CurrentPlayer == Player1,
                IsFirstPlayerHuman = Player1.IsHuman,
                IsSecondPlayerHuman = Player2.IsHuman,
            };
        }

        /// <summary>
        /// метод победы
        /// </summary>
        /// <param name="player"></param>
        private void ShowVictory(string player)
        {
            Form1 f = new Form1();
            f.ShowVictory(player);
        }
    }
}
