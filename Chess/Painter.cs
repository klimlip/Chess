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
        //public static Bitmap pawn1;
        //public static Bitmap pawn2;
        //public static Bitmap king1;
        //public static Bitmap king2;
        //public static Bitmap queen1;
        //public static Bitmap queen2;
        //public static Bitmap horse1;
        //public static Bitmap horse2;
        //public static Bitmap castle1;
        //public static Bitmap castle2;
        //public static Bitmap officer1;
        //public static Bitmap officer2;



        public Painter()
        {
            background = new Bitmap("Background.png");
            //pawn1 = new Bitmap("PAWN1.png");
            //pawn2 = new Bitmap("PAWN2.png");
            //queen1 = new Bitmap("QUEEN1.png");
            //queen2 = new Bitmap("QUEEN2.png");
            //king1 = new Bitmap("KING1.png");
            //king2 = new Bitmap("KING2.png");
            //horse1 = new Bitmap("horse1.png");
            //horse2 = new Bitmap("HORSE2.png");
            //castle1 = new Bitmap("CASTLE1.png");
            //castle2 = new Bitmap("CASTLE2.png");
            //officer1 = new Bitmap("OFFICER1.png");
            //officer2 = new Bitmap("OFFICER2.png");
        }

        public void Draw(Graphics g, List<IFigure> figure)
        {
            g.DrawImage(background, 0, 0, 500, 500);

            foreach (var f in figure)
            {
                //if(!f.player.isHuman)
                //{
                    var p = LocationInForm(f);
                    g.DrawImage(f.bitmap, p.X, p.Y, 51, 51);
                //}
            }
            //g.DrawImage(pawn2, 0, 0);
            //g.DrawImage(king2, 198,22, 35,35);
        }

        private static Point LocationInForm(IFigure f)
        {
            Point ret = new Point(32 + f.Location.X * 55, 32 + f.Location.Y * 55);
            //if(f.Location.Y == 7)
            //    return ret = new Point(35 + f.Location.X * 55, 20);
            //if (f.Location.Y == 6)
            //    return ret = new Point(35 + f.Location.X * 55, 65);

            return ret;
        }
    }
}
