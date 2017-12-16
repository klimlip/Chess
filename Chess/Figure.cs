using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    //public enum Color
    //{
    //    White,
    //    Black
    //}
    public class Figure
    {
        //public int X { get; private set; }
        //public int Y { get; private set; }

        public Point Location;
        //public Color color;
        public static int stepCount { get; private set; }
        public Player player { get; set; }
        //public bool isFirstPlayer { get; private set; }
        ///void Step(int X, int Y);
    }
    public class Pawn : Figure
    {
        public Pawn(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
        public void Step(int X, int Y)
        {
            if(player.isHuman)
            {
                if(stepCount == 0)
                {
                    if (Location.X + X <= 4 && Location.Y == Y)
                        Location.X = X;
                    
                }
            }
            
        }

    }

    class King : Figure
    {
        public King(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
    }
    class Queen : Figure
    {
        public Queen(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
    }
    class Horse : Figure
    {
        public Horse(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
    }
    class Officer : Figure
    {
        public Officer(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
    }
    class Castle : Figure
    {
        public Castle(int X, int Y, Player pl)
        {
            Location.X = X;
            Location.Y = Y;
            player = pl;
        }
    }

}
