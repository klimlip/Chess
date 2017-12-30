using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public interface IFigure
    {
        Point Location { get; set; }
        int stepCount { get; set; }
        Player player { get; set; }
    }

    public class Pawn : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public Pawn(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            stepCount = 0;
            this.player = player;
        }
        public void Step(int X, int Y)
        {
            if(player.isHuman)
            {
                if(stepCount == 0)
                {
                    if (Location.X + X <= 4 && Location.Y == Y)
                        Location = new Point(X, Y);                    
                }
            }            
        }
    }

    class King : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public King(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            stepCount = 0;
            player = pl;
        }
    }

    class Queen : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public Queen(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
        }
    }

    class Horse : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public Horse(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
        }
    }
    class Officer : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public Officer(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
        }
    }

    class Castle : IFigure
    {
        public Point Location { get; set; }
        public int stepCount { get; set; }
        public Player player { get; set; }
        public Castle(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
        }
    }

}
