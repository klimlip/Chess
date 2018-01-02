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
        bool[,] WhereCanIGo();
        void Step(int X, int Y);
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
            if ((!isOnTop && Location.Y == 7 ) || (isOnTop && Location.Y == 0))
            {
                GameField.newFigureX = Location.X;
                GameField.newFigureY = Location.Y;
                GameField.newPlayer = player;
                var window = new Choose_Figure();
                window.ShowDialog();
            }

        }

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            if (!isOnTop)
            {
                if ((firstStep && (GameField.field[Location.X, Location.Y + 1] == null && GameField.field[Location.X, Location.Y + 2] == null)))
                    ret[Location.X, Location.Y + 2] = true;
                if (GameField.field[Location.X, Location.Y + 1] == null)
                    ret[Location.X, Location.Y + 1] = true;
                if(Location.X !=7)
                    if (GameField.field[Location.X + 1, Location.Y + 1] != null && GameField.field[Location.X + 1, Location.Y + 1].player.color != player.color)
                        ret[Location.X + 1, Location.Y + 1] = true;
                if(Location.X !=0)
                    if (GameField.field[Location.X - 1, Location.Y + 1] != null && GameField.field[Location.X - 1, Location.Y + 1].player.color != player.color)
                        ret[Location.X - 1, Location.Y + 1] = true;
            }
            else
            {
                if ((firstStep && (GameField.field[Location.X, Location.Y - 1] == null && GameField.field[Location.X, Location.Y - 2] == null)))
                    ret[Location.X, Location.Y - 2] = true;
                if (GameField.field[Location.X, Location.Y - 1] == null)
                    ret[Location.X, Location.Y - 1] = true;
                if (Location.X != 7)
                    if (GameField.field[Location.X + 1, Location.Y - 1] != null && GameField.field[Location.X + 1, Location.Y - 1].player.color != player.color)
                        ret[Location.X + 1, Location.Y - 1] = true;
                if (Location.X != 0)
                    if (GameField.field[Location.X - 1, Location.Y - 1] != null && GameField.field[Location.X - 1, Location.Y - 1].player.color != player.color)
                        ret[Location.X - 1, Location.Y - 1] = true;
            }
            return ret;
        }

        private void ToDoStep(int X, int Y)
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
        public Player player { get; set; }
        public Bitmap bitmap { get; set; }

        public King(int X, int Y, Player player)
        {
            Location = new Point(X, Y);
            castlingPossible = true;
            this.player = player;
            if (this.player.color == Player.Color.White)
                bitmap = new Bitmap("king11.png");
            else
                bitmap = new Bitmap("king22.png");
        }

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            if (Location.X + 1 < 8 && Location.Y + 1 < 8 && GameField.field[Location.X + 1, Location.Y + 1].player.color != player.color)
                ret[Location.X + 1, Location.Y + 1] = true;
            if (Location.X + 1 < 8 && GameField.field[Location.X + 1, Location.Y].player.color != player.color)
                ret[Location.X + 1, Location.Y] = true;
            if (Location.X + 1 < 8 && Location.Y - 1 >=0 && GameField.field[Location.X + 1, Location.Y - 1].player.color != player.color)
                ret[Location.X + 1, Location.Y - 1] = true;
            if (Location.X - 1 >= 0 && Location.Y + 1 < 8 && GameField.field[Location.X - 1, Location.Y + 1].player.color != player.color)
                ret[Location.X - 1, Location.Y + 1] = true;
            if (Location.X - 1 >= 0 && GameField.field[Location.X - 1, Location.Y].player.color != player.color)
                ret[Location.X - 1, Location.Y] = true;
            if (Location.X - 1 >= 0 && Location.Y - 1 >= 0 && GameField.field[Location.X - 1, Location.Y - 1].player.color != player.color)
                ret[Location.X - 1, Location.Y - 1] = true;
            if (Location.Y + 1 < 8 && GameField.field[Location.X, Location.Y + 1].player.color != player.color)
                ret[Location.X, Location.Y + 1] = true;
            if (Location.Y - 1 >= 0 && GameField.field[Location.X, Location.Y - 1].player.color != player.color)
                ret[Location.X, Location.Y - 1] = true;
            return ret;
        }

        public void Step(int X, int Y)
        {
            var a = WhereCanIGo();
            if (a[X, Y] == true)
            {
                var oldPoint = Location;
                Location = new Point(X, Y);
                GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
                GameField.field[oldPoint.X, oldPoint.Y] = null;
            }
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

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            var x = Location.X;
            var y = Location.Y;
            while (x >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
            }
            x = Location.X;
            y = Location.Y;
            while (y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                y++;
            }
            x = Location.X;
            y = Location.Y;
            while (y >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                y--;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8 && y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
                y++;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8 && y >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
                y--;
            }
            x = Location.X;
            y = Location.Y;
            while (x >= 0 && y >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
                y--;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8 && y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
                y++;
            }

            return ret;
        }

        public void Step(int X, int Y)
        {
            var a = WhereCanIGo();
            if (a[X, Y] == true)
            {
                var oldPoint = Location;
                Location = new Point(X, Y);
                GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
                GameField.field[oldPoint.X, oldPoint.Y] = null;
            }
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

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            if (Location.X -2 >= 0 && Location.Y -1 >= 0 && GameField.field[Location.X - 2, Location.Y - 1].player.color != player.color)
                ret[Location.X -2, Location.Y - 1] = true;
            if (Location.X - 2 >= 0 && Location.Y + 1 < 8 && GameField.field[Location.X - 2, Location.Y + 1].player.color != player.color)
                ret[Location.X - 2, Location.Y + 1] = true;
            if (Location.X + 2 < 8 && Location.Y - 1 >= 0 && (GameField.field[Location.X + 2, Location.Y - 1] == null || GameField.field[Location.X + 2, Location.Y - 1].player.color != player.color))
                ret[Location.X + 2, Location.Y - 1] = true;
            if (Location.X + 2 < 8 && Location.Y + 1 < 8 && GameField.field[Location.X + 2, Location.Y + 1].player.color != player.color)
                ret[Location.X + 2, Location.Y + 1] = true;
            if (Location.X + 1 < 8 && Location.Y + 2 < 8 && (GameField.field[Location.X + 1, Location.Y + 2] == null || GameField.field[Location.X + 1, Location.Y + 2].player.color != player.color))
                ret[Location.X + 1, Location.Y + 2] = true;
            if (Location.X + 1 < 8 && Location.Y - 2 >= 0 && (GameField.field[Location.X + 1, Location.Y - 2] == null || GameField.field[Location.X + 1, Location.Y - 2].player.color != player.color))
                ret[Location.X + 1, Location.Y - 2] = true;
            if (Location.X - 1 >= 0 && Location.Y + 2 < 8 && (GameField.field[Location.X - 1, Location.Y + 2] == null || GameField.field[Location.X - 1, Location.Y + 2].player.color != player.color))
                ret[Location.X - 1, Location.Y + 2] = true;
            if (Location.X - 1 >= 0 && Location.Y - 2 >= 0 && (GameField.field[Location.X - 1, Location.Y - 2] == null || GameField.field[Location.X - 1, Location.Y - 2].player.color != player.color))
                ret[Location.X - 1, Location.Y - 2] = true;
            return ret;
        }

        public void Step(int X, int Y)
        {
            var a = WhereCanIGo();
            if (a[X, Y] == true)
            {
                var oldPoint = Location;
                Location = new Point(X, Y);
                GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
                GameField.field[oldPoint.X, oldPoint.Y] = null;
            }
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

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            var x = Location.X;
            var y = Location.Y;
            while(x < 8 && y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
                y++;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8 && y >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
                y--;
            }
            x = Location.X;
            y = Location.Y;
            while (x >= 0 && y >= 0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
                y--;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8 && y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
                y++;
            }
            return ret;
        }

        public void Step(int X, int Y)
        {
            var a = WhereCanIGo();
            if (a[X, Y] == true)
            {
                var oldPoint = Location;
                Location = new Point(X, Y);
                GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
                GameField.field[oldPoint.X, oldPoint.Y] = null;
            }
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

        public bool[,] WhereCanIGo()
        {
            bool[,] ret = new bool[8, 8];
            var x = Location.X;
            var y = Location.Y;
            while(x>=0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x--;
            }
            x = Location.X;
            y = Location.Y;
            while (x < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                x++;
            }
            x = Location.X;
            y = Location.Y;
            while (y < 8)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                y++;
            }
            x = Location.X;
            y = Location.Y;
            while (y >=0)
            {
                if (GameField.field[x, y] == null)
                    ret[x, y] = true;
                else if (GameField.field[x, y].player.color != player.color)
                {
                    ret[x, y] = true;
                    break;
                }
                else break;
                y--;
            }
            return ret;
        }

        public void Step(int X, int Y)
        {
            var a = WhereCanIGo();
            if (a[X, Y] == true)
            {
                var oldPoint = Location;
                Location = new Point(X, Y);
                GameField.field[Location.X, Location.Y] = GameField.field[oldPoint.X, oldPoint.Y];
                GameField.field[oldPoint.X, oldPoint.Y] = null;
            }
        }
    }
}
