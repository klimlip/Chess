﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class GameField
    {
        public static int newFigureX;
        public static int newFigureY;
        public static Player newPlayer;
        public static IFigure[,] field = new IFigure[8, 8];
        public void NewGame(bool firstIsHuman, bool secondIsHuman)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    field[i, j] = null;
            Player player1 = new Player(true, firstIsHuman);
            Player player2 = new Player(false, secondIsHuman);
            for (int i = 0; i <= 7; i++)
            {
                field[i, 1] = new Pawn(i, 1, false, player2);
                field[i, 6] = new Pawn(i, 6, true, player1);
            }
            for (int i = 0; i <= 7; i += 7)
            {
                field[i, 0] = new Rook(i, 0, player2);
                field[i, 7] = new Rook(i, 7, player1);
            }
            for (int i = 1; i <= 7; i += 5)
            {
                field[i, 0] = new Knight(i, 0, player2);
                field[i, 7] = new Knight(i, 7, player1);
            }
            for (int i = 2; i <= 6; i += 3)
            {
                field[i, 0] = new Bishop(i, 0, player2);
                field[i, 7] = new Bishop(i, 7, player1);
            }
            field[3, 0] = new Queen(3, 0, player2);
            field[3, 7] = new Queen(3, 7, player1);
            field[4, 0] = new King(4, 0, player2);
            field[4, 7] = new King(4, 7, player1);
            Game.king2 = (King)field[4, 0];
            Game.king1 = (King)field[4, 7];

        }

        public static Point PointFromForm(Point inForm)
        {
            return new Point((inForm.X - 32) / 55, (inForm.Y - 32) / 55);
        }

        public static void FindFigureFromPoint(Point p, ref string s)
        {
            for( int i = 0; i < 8; i++)
                for( int j = 0; j < 8; j++)
                {
                    if (field[i, j] != null && field[i, j].Location.X == p.X && field[i, j].Location.Y == p.Y)
                    {
                        Game.selectFigure = field[i, j];
                        break;
                    }
                }
            if (Game.selectFigure == null)
                s = "Слепой? Фигур не видишь что-ли?";
        }
    }
}
