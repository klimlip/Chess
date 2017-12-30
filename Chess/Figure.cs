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
        bool firstStep { get; set; } //true - еще не было шагов, false - уже были
        Player player { get; set; }
        Bitmap bitmap { get; set; }
    }

    public class Pawn : IFigure
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Pawn(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            firstStep = true;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("pawn11.png");
            else
                bitmap = new Bitmap("pawn22.png");
        }
        public void Step(int X, int Y)
        {
            if(player.isHuman)
            {
                if(firstStep)
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
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public King(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            firstStep = true;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("king11.png");
            else
                bitmap = new Bitmap("king22.png");
        }
    }

    class Queen : IFigure
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Queen(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("queen11.png");
            else
                bitmap = new Bitmap("queen22.png");
        }
    }

    class Knight : IFigure //рыцарь на коняшке
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Knight(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("knight11.png");
            else
                bitmap = new Bitmap("knight22.png");
        }
    }
    class Bishop : IFigure //слоник
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Bishop(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("bishop11.png");
            else
                bitmap = new Bitmap("bishop22.png");
        }
    }

    class Rook : IFigure //ладья
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Rook(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("rook11.png");
            else
                bitmap = new Bitmap("rook22.png");
        }
    }

}
