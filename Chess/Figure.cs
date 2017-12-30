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
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("PAWN1.png");
            else
                bitmap = new Bitmap("PAWN2.png");
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
        public King(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            firstStep = true;
            player = pl;
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("KING1.png");
            else
                bitmap = new Bitmap("KING2.png");
        }
    }

    class Queen : IFigure
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Queen(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("QUEEN1.png");
            else
                bitmap = new Bitmap("QUEEN2.png");
        }
    }

    class Knight : IFigure //рыцарь на коняшке
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Knight(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("HORSE1.png");
            else
                bitmap = new Bitmap("HORSE2.png");
        }
    }
    class Bishop : IFigure //слоник
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Bishop(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("OFFICER1.png");
            else
                bitmap = new Bitmap("OFFICER2.png");
        }
    }

    class Rook : IFigure //ладья
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Rook(int X, int Y, Player pl)
        {
            Location = new Point(X, Y);
            player = pl;
            if (player.color == Player.Color.White)
                bitmap = new Bitmap("CASTLE1.png");
            else
                bitmap = new Bitmap("CASTLE2.png");
        }
    }

}
