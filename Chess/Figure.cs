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
            #region
            //if (!isOnTop)
            //{
            //    if (firstStep && Y > 1 && Y <= 3 && Location.X == X && GameField.field[X, Y] == null)
            //    {
            //        ToDoStep(X, Y);
            //        firstStep = false;
            //    }
            //    else if (Y - Location.Y == 1 && Location.X == X && GameField.field[X, Y] == null)
            //        ToDoStep(X, Y);
            //    else if (Y - Location.Y == 1 && Math.Abs(X - Location.X) == 1 && GameField.field[X, Y].player.color != player.color)
            //        ToDoStep(X, Y);
            //}
            //else
            //{
            //    if (firstStep && Y < 6 && Y >= 4 && Location.X == X && GameField.field[X, Y] == null)
            //    {
            //        ToDoStep(X, Y);
            //        firstStep = false;
            //    }
            //    else if (Location.Y - Y == 1 && Location.X == X && GameField.field[X, Y] == null)
            //        ToDoStep(X, Y);
            //    else if (Location.Y - Y == 1 && Math.Abs(Location.X - X) == 1 && GameField.field[X, Y].player.color != player.color)
            //        ToDoStep(X, Y);
            //}
#endregion

            var a = WhereCanIGo();
            if (a[X, Y] == true)
                ToDoStep(X, Y);
        }

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            if (!isOnTop)
            {
<<<<<<< HEAD
                if (firstStep && Y > 1 && Y <= 3 && Location.X == X && GameField.field[X, Y] == null)
                {
                    DoStep(X, Y);
                    firstStep = false;
                }
                else if (Y - Location.Y == 1 && Location.X == X && GameField.field[X, Y] == null)
                    DoStep(X, Y);
                else if (Y - Location.Y == 1 && Math.Abs(X - Location.X) == 1 && GameField.field[X, Y].player.color != player.color)
                    DoStep(X, Y);
            }
            else
            {
                if (firstStep && Y < 6 && Y >= 4 && Location.X == X && GameField.field[X, Y] == null)
                {
                    DoStep(X, Y);
                    firstStep = false;
                }
                else if (Location.Y - Y == 1 && Location.X == X && GameField.field[X, Y] == null)
                    DoStep(X, Y);
                else if (Location.Y - Y == 1 && Math.Abs(Location.X - X) == 1 && GameField.field[X, Y].player.color != player.color)
                    DoStep(X, Y);
=======
                if ((firstStep && (GameField.field[Location.X, Location.Y + 1] == null && GameField.field[Location.X, Location.Y + 2] == null)))
                    ret[Location.X, Location.Y + 2] = true;
                if (GameField.field[Location.X, Location.Y + 1] == null)
                    ret[Location.X, Location.Y + 1] = true;
                if (GameField.field[Location.X + 1, Location.Y + 1].player.color != player.color)
                    ret[Location.X + 1, Location.Y + 1] = true;
                if (GameField.field[Location.X - 1, Location.Y + 1].player.color != player.color)
                    ret[Location.X - 1, Location.Y + 1] = true;
            }
            else
            {
                if ((firstStep && (GameField.field[Location.X, Location.Y - 1] == null && GameField.field[Location.X, Location.Y - 2] == null)))
                    ret[Location.X, Location.Y - 2] = true;
                if (GameField.field[Location.X, Location.Y - 1] == null)
                    ret[Location.X, Location.Y + 1] = true;
                if (GameField.field[Location.X + 1, Location.Y - 1].player.color != player.color)
                    ret[Location.X + 1, Location.Y - 1] = true;
                if (GameField.field[Location.X - 1, Location.Y - 1].player.color != player.color)
                    ret[Location.X - 1, Location.Y - 1] = true;
>>>>>>> 1f96846e719e4fbaae9e896e972a41e60b191800
            }
            return ret;
        }

        private void DoStep(int X, int Y)
        {
            var oldPoint = Location;
            firstStep = false;
            Location = new Point(X, Y);
            GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
            GameField.field[oldPoint.X, oldPoint.Y] = null;
        }
    }

    class King : IFigure
    {
        public Point Location { get; set; }
        public bool castlingPossible { get; set; }
        public bool whiteOnTop;
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }
        public King(int X, int Y, bool isOnTop, Player player)
        {
            Location = new Point(X, Y);
            castlingPossible = true;
            this.whiteOnTop = isOnTop;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("king11.png");
            else
                bitmap = new Bitmap("king22.png");
        }
        public void Step(int X, int Y)
        {
            var oldPoint = Location;
            Location = new Point(X, Y);
            castlingPossible = true;
            if (castlingPossible)
            {
                if (whiteOnTop)
                    if (oldPoint.Y == Y && (oldPoint.X - X == 2 && GameField.field[1, Y] == null && GameField.field[2, Y] == null && GameField.field[Y,0]!=null && GameField.field[Y,0].firstStep) || (oldPoint.X - X == -2 && GameField.field[6, Y] == null && GameField.field[5, Y] == null && GameField.field[4, Y] == null))
                    {
                        DoStep(X, Y);
                        castlingPossible = false;
                    }
                    else;
                else
                if (oldPoint.Y == Y && (oldPoint.X - X == 2 && GameField.field[1, Y] == null && GameField.field[2, Y] == null && GameField.field[3, Y] == null) || (oldPoint.X - X == 2 && GameField.field[5, Y] == null && GameField.field[6, Y] == null))
                {
                    DoStep(X, Y);
                    castlingPossible = false;
                }
            }
        }
        private void DoStep(int X, int Y)
        {
            var oldPoint = Location;
            Location = new Point(X, Y);
            GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
            GameField.field[oldPoint.X, oldPoint.Y] = null;
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
        public bool firsStep;
        public Rook(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            firsStep = true;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("rook11.png");
            else
                bitmap = new Bitmap("rook22.png");
        }
    }

}
