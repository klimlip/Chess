using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public enum Color
    {
        White,
        Black
    }
    public class Figure
    {
        //public int X { get; private set; }
        //public int Y { get; private set; }

        public Point Location { get; private set; }
        //public Color color;
        public int stepCount;
        public Player player { get; private set; }
        //public bool isFirstPlayer { get; private set; }


        public Figure(int x, int y)
        {
            stepCount = 0;

        }
    }
    class Pawn : Figure
    {
        
    }
}
