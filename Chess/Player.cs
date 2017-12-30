using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Player
    {
        public enum Color
        {
            White,
            Black
        }

        public Color color;
        public bool isHuman { get; private set; }  // true - first 
        //какая-то хрень с человеком, он должен знать, человек он или нет и знать, белый он или черный

        public Player(bool isFirst, bool isHuman)
        {
            if (isFirst)
                color = Color.White;
            else
                color = Color.Black;
            this.isHuman = isHuman;
        }
    }
}
