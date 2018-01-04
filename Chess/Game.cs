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

        public void FirstPartOfStep(Point p)
        {
            GameField.FindFigureFromPoint(p);
            if (selectFigure.player.color == Player.Color.White)
            {
                if (isWhitesTurn)
                {
                    selectFigure = null;
                    throw new Exception("Ходят белые!");
                }
            }
            else
            {
                if(!isWhitesTurn)
                {
                    selectFigure = null;
                    throw new Exception("Ходят чёрные!");
                }
            }

        }

        public void SecondPartOfStep(Point p, Graphics g)
        {
            if (selectFigure != null)
            {
                var check = selectFigure.Step(p.X, p.Y);
                if (check)
                {
                    Draw(g);
                    if (isWhitesTurn)
                        isWhitesTurn = false;
                    else isWhitesTurn = true;
                }
                else throw new Exception("Надо переходить, а то ты объ*балася)");
            }
            else throw new Exception("Выбериту фигуру");
        }


    }
}
