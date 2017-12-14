using System.Collections.Generic;
using System.Drawing;
namespace oop3
{
    /// <summary>
    /// класс хода
    /// </summary>
    public class Move
    {
        public Figure Figure { get; private set; }
        public Point NewLocation { get; private set; }
        public bool IsKillingMove { get; private set; }

        public Move(Point newLocation, bool isKillingMove, Figure figure)
        {
            this.NewLocation = newLocation;
            this.IsKillingMove = isKillingMove;
            this.Figure = figure;
        }
    }
}
