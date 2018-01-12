using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Game
    {
        public static IFigure selectFigure;
        private bool firstStep;
        public static King king1;
        public static King king2;
        public static bool isWhitesTurn = true;
        public static GameField gameField;
        public static Painter painter;

        public Game(bool firstIsHuman, bool secondIsHuman, bool WhiteOnTop, Graphics g)
        {
            gameField = new GameField();
            painter = new Painter();
            gameField.NewGame(firstIsHuman, secondIsHuman, WhiteOnTop);
            painter.Draw(g, GameField.field);
            isWhitesTurn = true;
        }

        public void Draw(Graphics g)
        {
            painter.Draw(g, GameField.field);
        }

        public IFigure FirstPartOfStep(Point p)
        {
            GameField.FindFigureFromPoint(p);
            firstStep = true;
            var can = CanIGoThisFigure();
            if (can)
            {
                if (selectFigure.player.color == Player.Color.White)
                {
                    if (isWhitesTurn)
                    {
                        selectFigure = null;
                        throw new Exception("Ходят белые!");
                    }
                    return selectFigure;
                }
                else
                {
                    if (!isWhitesTurn)
                    {
                        selectFigure = null;
                        throw new Exception("Ходят чёрные!");
                    }
                    return selectFigure;
                }
            }
            else throw new Exception("Нельзы выбрать данную фигуру");

        }

        public IFigure SecondPartOfStep(Point p, Graphics g)
        {
            if (selectFigure != null && firstStep)
            {
                var check = selectFigure.Step(p.X, p.Y);
                if (check && firstStep)
                {
                    if (isWhitesTurn)
                        isWhitesTurn = false;
                    else
                        isWhitesTurn = true;
                    firstStep = false;
                    return selectFigure;
                }
                throw new Exception("Фигура так не ходит");
            }
            else throw new Exception("Выберите фигуру");
        }

        public void ComputerDoStep(Graphics g, bool isFirstComp, bool isSecondComp)
        {
            Random rand = new Random();
            int x, y;
            bool check = false;
            bool[,] a;
            List<Point> listOfInde = new List<Point>();
            if (isWhitesTurn && isFirstComp)
            {
                do
                {
                    do
                    {
                        do
                        {
                            x = rand.Next(8);
                            y = rand.Next(8);
                        }
                        while (GameField.field[x, y] == null || GameField.field[x, y].player.color == Player.Color.White);
                        selectFigure = GameField.field[x, y];
                        a = selectFigure.WhereCanIGo();
                    } while (!HaveTrue(a));

                    var matr = GameField.field[x, y].WhereCanIGo();

                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            if (matr[j, i])
                                listOfInde.Add(new Point(j, i));

                    int randomPoint = rand.Next(listOfInde.Count);

                    check = GameField.field[x, y].Step(listOfInde[randomPoint].X, listOfInde[randomPoint].Y);

                } while (!check);

                isWhitesTurn = false;
                painter.Draw(g, GameField.field);
            }
            else if(!isWhitesTurn && isSecondComp)
            {
                do
                {
                    do
                    {
                        do
                        {
                            x = rand.Next(8);
                            y = rand.Next(8);
                        }
                        while (GameField.field[x, y] == null || GameField.field[x, y].player.color == Player.Color.Black);
                        selectFigure = GameField.field[x, y];
                        a = selectFigure.WhereCanIGo();
                    } while (!HaveTrue(a));

                    var matr = GameField.field[x, y].WhereCanIGo();

                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            if (matr[j, i])
                                listOfInde.Add(new Point(j, i));

                    int randomPoint = rand.Next(listOfInde.Count);

                    check = GameField.field[x, y].Step(listOfInde[randomPoint].X, listOfInde[randomPoint].Y);

                } while (!check);
                isWhitesTurn = true;
                painter.Draw(g, GameField.field);
            }
        }
        

        public bool CanIGoThisFigure()////невсегдарабочаяхерня
        {
            GameField.field[selectFigure.Location.X, selectFigure.Location.Y] = null;
            if (selectFigure.player.color == Player.Color.White)
            {
                foreach(var f in GameField.field)
                {
                    if (f != null && f.player.color == Player.Color.Black)
                    {
                        bool[,] a = new bool[8, 8];
                        a = f.WhereCanIGo();
                        if (a[king1.Location.X, king1.Location.Y])
                        {
                            GameField.field[selectFigure.Location.X, selectFigure.Location.Y] = selectFigure;
                            return false;
                        }
                    }
                }
            }
            else
            {
                foreach (var f in GameField.field)
                {
                    if (f != null && f.player.color == Player.Color.White)
                    {
                        bool[,] a = new bool[8, 8];
                        a = f.WhereCanIGo();
                        if (a[king2.Location.X, king2.Location.Y])
                        {
                            GameField.field[selectFigure.Location.X, selectFigure.Location.Y] = selectFigure;
                            return false;
                        }
                    }

                }
            }
            GameField.field[selectFigure.Location.X, selectFigure.Location.Y] = selectFigure;
            return true;
        }

        private bool IfCheck(King king)
        {
            foreach (var figure in GameField.field)
            {
                if (figure.player == king.player) continue;
                if (figure.WhereCanIGo()[king.Location.X, king.Location.Y]) return true; ;
            }
            return false;
        }

        public static bool HaveTrue(bool[,] matr)
        {
            foreach (var a in matr)
                if (a)
                    return true;
            return false;

        }
    }
}
