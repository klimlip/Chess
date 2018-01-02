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

        public Painter()
        {
            background = new Bitmap("Background.png");
        }

        public void Draw(Graphics g, IFigure[,] field)
        {
            g.Clear(Color.FromArgb(155, 123, 198));
            g.DrawImage(background, 0, 0, 500, 500);

            foreach (var f in field)
            { 
                if (f != null)
                {
                    var p = LocationInForm(f);
                    g.DrawImage(f.bitmap, p.X, p.Y, 51, 51);
                }
            }
        }

        private static Point LocationInForm(IFigure f)
        {
            Point ret = new Point(32 + f.Location.X * 55, 32 + f.Location.Y * 55);
            return ret;
        }
    }
}
