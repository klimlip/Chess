using System.Drawing;
using System.Linq;
namespace oop3
{
    /// <summary>
    /// класс для паттерна Adapter, Target = Form, Adaptee = Player, SpecificRequest() = FinishMove()
    /// </summary>
    public class HumanPlayersAdapter
    {
        private Figure lastSelected;

        /// <summary>
        /// метод обработки клика
        /// </summary>
        /// <param name="point"></param>
        public void Click(Point point)
        {
            var currentPlayer = Game.Instance.CurrentPlayer;

            if (!currentPlayer.IsHuman)
            {
                return;
            }

            var figure = Game.Instance.GetPlayerFigures(currentPlayer).FirstOrDefault(f => f.Location.Equals(point));

            if (lastSelected != null && figure == null)//если уже выбрана шашка, делаем ход и освобождаем выбор
            {
                currentPlayer.FinishMove(lastSelected, point);
                lastSelected = null;
            }
            else
            {
                lastSelected = figure;
            }

        }
    }
}
