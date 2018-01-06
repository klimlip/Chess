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
                    if (f.IsChosen)
                    {
                        SolidBrush sb = new SolidBrush(Color.FromArgb(50, 0, 255, 10));
                        g.FillRectangle(Brushes.White, 30 + f.Location.X * 55, 30 + f.Location.Y * 55, 55, 55);
                        g.DrawRectangle(Pens.Green, 30 + f.Location.X * 55, 30 + f.Location.Y * 55, 55, 55);
                        g.FillRectangle(sb, 30 + f.Location.X * 55, 30 + f.Location.Y * 55, 55, 55);
                        var PossibleSteps = f.WhereCanIGo();
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (PossibleSteps[i, j])
                                {
                                    g.FillEllipse(Brushes.White, 47 + i * 55, 47 + j * 55, 20, 20);
                                    g.DrawEllipse(Pens.Green, 47 + i * 55, 47 + j * 55, 20, 20);
                                    g.FillEllipse(sb, 47 + i * 55, 47 + j * 55, 20, 20);
                                }
                    }
                    g.DrawImage(f.bitmap, p.X, p.Y, 51, 51);

                }
            }
        }

        public static void WhereCanFigureGo(Graphics g, IFigure ifi)
        {
            var a = ifi.WhereCanIGo();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (a[i, j] == true)
                    {
                        g.DrawEllipse(Pens.Red, 32 + i * 55, 32 + j * 55, 60, 60);
                        g.FillEllipse(Brushes.Red, 32 + i * 55, 32 + j * 55, 60, 60);
                    }
        }

        private static Point LocationInForm(IFigure f)
        {
            Point ret = new Point(32 + f.Location.X * 55, 32 + f.Location.Y * 55);
            return ret;
        }
    }
}
