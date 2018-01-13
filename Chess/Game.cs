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

        public IFigure FirstPartOfStep(Point p, ref string s)
        {
            GameField.FindFigureFromPoint(p, ref s);
            if (s != "")
                return null;
            firstStep = true;
            var can = CanIGoThisFigure();
            if (can)
            {
                if (selectFigure.player.color == Player.Color.White)
                {
                    if (isWhitesTurn)
                    {
                        selectFigure = null;
                        s = "Ходят белые!";
                    }
                    return selectFigure;
                }
                else
                {
                    if (!isWhitesTurn)
                    {
                        selectFigure = null;
                        s = "Ходят чёрные!";
                    }
                    return selectFigure;
                }
            }
            else
            {
                selectFigure = null;
                s = "Нельзы выбрать данную фигуру";
                return null;
            }

        }

        public IFigure SecondPartOfStep(Point p, Graphics g, ref string s)
        {
            if (selectFigure != null && firstStep)
            {
                var check = selectFigure.Step(p.X, p.Y);
                if (check && firstStep)
                {
                    if (isWhitesTurn)
                    {
                        isWhitesTurn = false;
                        if (IfCheck(king2, GameField.field))
                            s = "Черным шах";
                    }
                    else
                    {
                        isWhitesTurn = true;
                        if (IfCheck(king1, GameField.field))
                            s = "Белым шах";
                    }
                    firstStep = false;
                    return selectFigure;
                }
                s = "Фигура так не ходит";
                return null;
            }
            else
            {
                s = "Выберите фигуру";
                return null;
            }
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
            bool a;
            IFigure[,] tmpField = new IFigure[8, 8];
            foreach (var f in GameField.field)
            {
                if (f != null)
                    tmpField[f.Location.X, f.Location.Y] = f;
            }
            tmpField[selectFigure.Location.X, selectFigure.Location.Y] = null;
            if (selectFigure.player.color == Player.Color.White)
            {
                a = IfCheck(king2, tmpField);
            }
            else
            {
                a = IfCheck(king1, tmpField);
            }
            return a;
        }

        public static bool IfCheck(King king, IFigure[,] field)
        {
            foreach (var figure in field)
            {
                if (figure == null || figure.player == king.player) continue;
                if (figure.WhereCanIGo()[king.Location.X, king.Location.Y]) return true;
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
