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
        public bool isHuman { get; private set; }
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
