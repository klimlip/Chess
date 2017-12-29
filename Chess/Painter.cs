using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public class Painter
    {
        public static Bitmap background;
        public static Bitmap pawn1;
        public static Bitmap pawn2;
        public static Bitmap king2;
        public static Bitmap queen2;
        public static Bitmap horse2;
        public static Bitmap castle2;
        public static Bitmap officer2;



        public Painter()
        {
            background = new Bitmap("Fone.jpg");
            king2 = new Bitmap("KING2.png");
            pawn2 = new Bitmap("PAWN2.png");
            queen2 = new Bitmap("QUEEN2.png");
            horse2 = new Bitmap("HORSE2.png");
            castle2 = new Bitmap("CASTLE2.png");
            officer2 = new Bitmap("OFFICER2.png");
        }

        public void Draw(Graphics g, List<Figure> figure)
        {
            g.DrawImage(background, 0, 0, 384, 384);

            foreach (var f in figure)
            {
                if(!f.player.isHuman)
                {
                    var p = LocationInForm(f);
                    g.DrawImage(f.bitmap, p.X, p.Y, 35, 35);
                }
            }
            //g.DrawImage(pawn2, 0, 0);
            //g.DrawImage(king2, 198,22, 35,35);
        }

        private static Point LocationInForm(Figure f)
        {
            Point ret = new Point();
            if(f.Location.Y == 7)
                return ret = new Point(20 + f.Location.X * 44, 20);
            if (f.Location.Y == 6)
                return ret = new Point(20 + f.Location.X * 44, 65);

            return ret;
        }
    }
}
