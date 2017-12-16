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

        public Player(bool isFirst)
        {
            this.isHuman = isFirst;
            if (isHuman)
                color = Color.White;
            else
                color = Color.Black;
        }

    }
}
