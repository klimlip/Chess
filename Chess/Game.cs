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
        public static bool isWhitesTurn;
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


    }
}
