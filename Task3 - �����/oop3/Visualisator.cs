using oop3.Resources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace oop3
{
    /// <summary>
    /// класс для паттерна Observer (ConcreteObserver)
    /// </summary>
    public class Visualisator: IGameFieldNotificationObserver
    {
        private static Visualisator instance;

        private readonly Func<Graphics> getGraphicsFunc;
        private readonly Bitmap fone;
        private readonly Bitmap firtsPlayerSimpleFigure;
        private readonly Bitmap secondPlayerSimpleFigure;
        private readonly Bitmap firtsPlayerKingFigure;
        private readonly Bitmap secondPlayerKingFigure;
        private readonly int cellSideSize;
        private readonly int frameWidth;
        private readonly GameField gameField;

        //------------------- делаем класс одиночкой -----------
        public static Visualisator Instance { get { return instance; } }

        private Visualisator(Func<Graphics> getGraphicsFunc, GameField gameField)
        {
            this.getGraphicsFunc = getGraphicsFunc;
            this.fone = this.LoadBitmap("GameFieldFonePath");
            this.firtsPlayerSimpleFigure = this.LoadBitmap("FirstPlayerSimpleFigurePath");
            this.secondPlayerSimpleFigure = this.LoadBitmap("SecondPlayerSimpleFigurePath");
            this.firtsPlayerKingFigure = this.LoadBitmap("FirstPlayerKingFigurePath");
            this.secondPlayerKingFigure = this.LoadBitmap("SecondPlayerKingFigurePath");
            this.frameWidth = (int)Settings.Default["FrameWidth"];
            this.cellSideSize = (int)Settings.Default["CellSideSize"];
            this.gameField = gameField;
        }


        public static void CreateInstance(Func<Graphics> getGraphicsFunc, GameField gameField)
        {
            instance = new Visualisator(getGraphicsFunc, gameField);
        }
        //-----------------------------------

        /// <summary>
        /// иетод обновления (перерисовки)
        /// </summary>
        public void Update()
        {
            this.Draw(gameField.FiguresInfo);
        }

        /// <summary>
        /// метод отрисовки
        /// </summary>
        /// <param name="figures"></param>
        private void Draw(List<FigureInfo> figures)
        {
            var fone = (Bitmap)this.fone.Clone();
            figures.ForEach(x => this.DrawFigure(fone, x));

            using (var graphics = this.getGraphicsFunc())
            {
                graphics.DrawImage(fone, graphics.VisibleClipBounds);
            }
        }

        /// <summary>
        /// метод отрисовки фигур
        /// </summary>
        /// <param name="fone"></param>
        /// <param name="figure"></param>
        private void DrawFigure(Bitmap fone, FigureInfo figure)
        {
            var topLeftPoint = this.GetFigureCoordinates(figure);
            var figureBitmap = this.GetFigureBitmap(figure);
            this.DrawFigureOnBitmap(fone, topLeftPoint, figureBitmap);
        }

        /// <summary>
        /// метод получения координат фигур
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        private Point GetFigureCoordinates(FigureInfo figure)
        {
            var x = frameWidth + (figure.X - 1) * cellSideSize;
            var y = frameWidth + (figure.Y - 1) * cellSideSize;
            return new Point(x, y);
        }

        /// <summary>
        /// метод выбора картинки для шашки
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        private Bitmap GetFigureBitmap(FigureInfo figure)
        {
            var figureBitmap = figure.IsFirstPlayer
                ? (figure.IsKing ? firtsPlayerKingFigure : firtsPlayerSimpleFigure)
                : (figure.IsKing ? secondPlayerKingFigure : secondPlayerSimpleFigure);

            return figureBitmap;
        }

        /// <summary>
        /// метод для отрисовки (путем копирования пикселей)
        /// </summary>
        /// <param name="fone"></param>
        /// <param name="point"></param>
        /// <param name="figure"></param>
        private void DrawFigureOnBitmap(Bitmap fone, Point point, Bitmap figure)
        {
            var srcRect = new Rectangle(0, 0, figure.Width, figure.Height);
            var srcBitmapData = figure.LockBits(srcRect,
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            var dstRect = new Rectangle(point.X, point.Y, figure.Width, figure.Width);
            var dstBitmapData = fone.LockBits(dstRect,
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            try
            {
                unsafe
                {
                    var srcPixels = (byte*)srcBitmapData.Scan0.ToPointer();
                    var dstPixels = (byte*)dstBitmapData.Scan0.ToPointer();
                    for (var y = 0; y < srcBitmapData.Height; y++)
                    {
                        for (var x = 0; x < (srcBitmapData.Width) * 3; x += 3)
                        {
                                for (var i = 0; i < 3; i++)
                                    dstPixels[x + i] = srcPixels[x + i];
                        }
                        dstPixels += dstBitmapData.Stride;
                        srcPixels += srcBitmapData.Stride;
                    }
                }
            }
            finally
            {
                figure.UnlockBits(srcBitmapData);
                fone.UnlockBits(dstBitmapData);
            }
        }

        /// <summary>
        /// метод загрузки картинки
        /// </summary>
        /// <param name="bitmapName"></param>
        /// <returns></returns>
        private Bitmap LoadBitmap(string bitmapName)
        {
            var path = (string)Settings.Default[bitmapName];
            var fone = (Bitmap)Bitmap.FromFile(path);
            return fone;
        }
    }
}
