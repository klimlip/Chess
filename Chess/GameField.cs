using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class GameField
    {
        public static List<IFigure> figures = new List<IFigure>();
        public static IFigure[,] field = new IFigure[8, 8];
        public void NewGame(bool firstIsHuman, bool secondIsHuman, bool WhiteOnTop)
        {
            Player player1 = new Player(true, firstIsHuman);
            Player player2 = new Player(false, secondIsHuman);
            if (!WhiteOnTop)
                for (int i = 0; i <= 7; i++)
                {
                    Pawn pawn1 = new Pawn(i, 1, player1);
                    Pawn pawn2 = new Pawn(i, 6, player2);
                    figures.Add(pawn1);
                    figures.Add(pawn2);
                }
            else
                for (int i = 0; i <= 7; i++)
                {
                    Pawn pawn1 = new Pawn(i, 6, player1);
                    Pawn pawn2 = new Pawn(i, 1, player2);
                    figures.Add(pawn1);
                    figures.Add(pawn2);
                } // создаем пешки
            if (!WhiteOnTop)
                for (int i = 0; i <= 7; i += 7)
                {
                    Rook ca1 = new Rook(i, 0, player1);
                    Rook ca2 = new Rook(i, 7, player2);
                    figures.Add(ca1);
                    figures.Add(ca2);
                }               
            else
                for (int i = 0; i <= 7; i += 7)
                {
                    Rook ca1 = new Rook(i, 7, player1);
                    Rook ca2 = new Rook(i, 0, player2);
                    figures.Add(ca1);
                    figures.Add(ca2);
                }                 // создаем ладьи
            if (!WhiteOnTop)
                for (int i = 1; i <= 7; i += 5)
                {
                    Knight ho1 = new Knight(i, 0, player1);
                    Knight ho2 = new Knight(i, 7, player2);
                    figures.Add(ho1);
                    figures.Add(ho2);
                }           
            else
                for (int i = 1; i <= 7; i += 5)
                {
                    Knight ho1 = new Knight(i, 7, player1);
                    Knight ho2 = new Knight(i, 0, player2);
                    figures.Add(ho1);
                    figures.Add(ho2);
                }        // создаем коней
            if (!WhiteOnTop)
                for (int i = 2; i <= 6; i += 3)
                {
                    Bishop of1 = new Bishop(i, 0, player1);
                    Bishop of2 = new Bishop(i, 7, player2);
                    figures.Add(of1);
                    figures.Add(of2);
                }                               
            else
                for (int i = 2; i <= 6; i += 3)
                {
                    Bishop of1 = new Bishop(i, 7, player1);
                    Bishop of2 = new Bishop(i, 0, player2);
                    figures.Add(of1);
                    figures.Add(of2);
                }    // создаем слоников
            if (!WhiteOnTop)
            {
                Queen q1 = new Queen(3, 0, player1);
                Queen q2 = new Queen(3, 7, player2);
                King k1 = new King(4, 0, player1);
                King k2 = new King(4, 7, player2);
                figures.Add(q1);
                figures.Add(q2);
                figures.Add(k1);
                figures.Add(k2);
            }
            else
            {
                Queen q1 = new Queen(3, 7, player1);
                Queen q2 = new Queen(3, 0, player2);
                King k1 = new King(4, 7, player1);
                King k2 = new King(4, 0, player2);
                figures.Add(q1);
                figures.Add(q2);
                figures.Add(k1);
                figures.Add(k2);
            }
            //создаем королей и ферзей

            foreach (var f in figures)
            {
                field[f.Location.X, f.Location.Y] = f;
            }                                     // заполнили массив поля(я про него забыл, поэтому заполняем так)
        }

    }
}
