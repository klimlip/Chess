using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class GameField
    {
        public static List<Figure> figures;

        public static void NewGame()
        {
            for(int i = 1; i<= 8; i++)
            {
                Player pl1 = new Player(true);
                Pawn pw1 = new Pawn(i, 2, pl1);
                Player pl2 = new Player(false);
                Pawn pw2 = new Pawn(i, 7, pl2);
                figures.Add(pw1);
                figures.Add(pw2);
            }

        }

    }
}
