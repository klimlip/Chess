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
            if (selectFigure != null)
            {
                bool KingKilled = false;
                if (GameField.field[p.X, p.Y] != null && GameField.field[p.X, p.Y] is King && GameField.field[p.X, p.Y].player != selectFigure.player)
                    KingKilled = true;
                var check = selectFigure.Step(p.X, p.Y);
                if (check)
                {
                    if (isWhitesTurn)
                    {
                        if (KingKilled)
                            throw new Exception("Белые победюкали!");
                        else
                            isWhitesTurn = false;
                    }
                    else
                    {
                        if (KingKilled)
                            throw new Exception("Черные победюкали!");
                        else
                            isWhitesTurn = true;
                    }
                    return selectFigure;
                }
                else throw new Exception("Надо переходить, а то ты объ*бался)");
            }
            else throw new Exception("Выберите фигуру");
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
    }
}
