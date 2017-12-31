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
        Player player { get; set; }
        Bitmap bitmap { get; set; }
    }

    public class Pawn : IFigure
    {
        public Point Location { get; set; }
        public bool firstStep { get; set; }
        private bool isOnTop;
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public Pawn(int X, int Y, bool isOnTop, Player player)
        {
            Location = new Point(X, Y);
            firstStep = true;
            this.isOnTop = isOnTop;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("pawn11.png");
            else
                bitmap = new Bitmap("pawn22.png");
        }
        public void Step(int X, int Y)
        {
            if (!isOnTop)
            {
                if (firstStep && Y > 1 && Y <= 3 && Location.X == X && GameField.field[X, Y] == null)
                {
                    ToDoStep(X, Y);
                    firstStep = false;
                }
                else if (Y - Location.Y == 1 && Location.X == X && GameField.field[X, Y] == null)
                    ToDoStep(X, Y);
                else if (Y - Location.Y == 1 && Math.Abs(X - Location.X) == 1 && GameField.field[X, Y].player.color != player.color)
                    ToDoStep(X, Y);
            }
            else
            {
                if (firstStep && Y < 6 && Y >= 4 && Location.X == X && GameField.field[X, Y] == null)
                {
                    ToDoStep(X, Y);
                    firstStep = false;
                }
                else if (Location.Y - Y == 1 && Location.X == X && GameField.field[X, Y] == null)
                    ToDoStep(X, Y);
                else if (Location.Y - Y == 1 && Math.Abs(Location.X - X) == 1 && GameField.field[X, Y].player.color != player.color)
                    ToDoStep(X, Y);
            }
        }

        private void ToDoStep(int X, int Y)
        {
            var oldPoint = Location;
            Location = new Point(X, Y);
            GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
            GameField.field[oldPoint.X, oldPoint.Y] = null;
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
