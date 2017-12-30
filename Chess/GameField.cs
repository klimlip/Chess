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
        public void NewGame()
        {
            Player player1 = new Player(true);
            Player player2 = new Player(false);
            for(int i = 0; i<= 7; i++) 
            {
                Pawn pawn1 = new Pawn(i, 1, player1);
                Pawn pawn2 = new Pawn(i, 6, player2);
                figures.Add(pawn1);
                figures.Add(pawn2);
            }                               // placement of pawns
            for(int i = 0; i <= 7; i += 7)
            { 
                Castle ca1 = new Castle(i, 0, player1);
                Castle ca2 = new Castle(i, 7, player2);
                figures.Add(ca1);
                figures.Add(ca2);
            }                           // placement of castles
            for(int i = 1; i <= 7; i+= 5)
            {
                Horse ho1 = new Horse(i, 0, player1);
                Horse ho2 = new Horse(i, 7, player2);
                figures.Add(ho1);
                figures.Add(ho2);
            }                            // placement of horses
            for(int i = 2; i<=6; i+=3)
            {
                Officer of1 = new Officer(i, 0, player1);
                Officer of2 = new Officer(i, 7, player2);
                figures.Add(of1);
                figures.Add(of2);
            }                               // placement of officers
            Queen q1 = new Queen(3, 0, player1);
            Queen q2 = new Queen(3, 7, player2);
            King k1 = new King(4, 0, player1);
            King k2 = new King(4, 7, player2);
            figures.Add(q1);
            figures.Add(q2);
            figures.Add(k1);
            figures.Add(k2);


            foreach (var f in figures)
            {
                field[f.Location.X, f.Location.Y] = f;
            }                                     // заполнили массив поля(я про него забыл, поэтому заполняем так)
        }

    }
}
