using oop3.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop3
{
    public partial class Form1 : Form, IGameFieldNotificationPublisher
    {
        private readonly List<IGameFieldNotificationObserver> observers;
        private readonly HumanPlayersAdapter playerAdapter;

        private int x;
        private int y;

        public Form1()
        {
            InitializeComponent();

            this.observers = new List<IGameFieldNotificationObserver>();
            playerAdapter = new HumanPlayersAdapter();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Game.CreateInstance(this.pbGame.CreateGraphics, radioButton1.Checked ? false : true, radioButton4.Checked ? false : true);

            if (Visualisator.Instance != null)
            {
                this.Attach(Visualisator.Instance);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void ShowVictory(string player)
        {
            MessageBox.Show(player + " win!");
        }

        /// <summary>
        /// метод паттерна Observer, добавление наблюдателей
        /// </summary>
        /// <param name="observers"></param>
        public void Attach(params IGameFieldNotificationObserver[] observers)
        {
            this.observers.AddRange(observers);
            observers.ToList().ForEach(x => x.Update());
        }

        /// <summary>
        /// метод паттерна Observer
        /// </summary>
        public void Notify()
        {
            this.observers.ForEach(x => x.Update());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pbGame_Paint(object sender, PaintEventArgs e)
        {
            this.Notify();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.Notify();
        }

        private void pbGame_SizeChanged(object sender, EventArgs e)
        {
            this.Notify();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK || saveFileDialog.ShowDialog() == DialogResult.Yes)
            {
                if (Game.Instance != null)
                {
                    Game.Instance.Serialize(saveFileDialog.FileName);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK || openFileDialog.ShowDialog() == DialogResult.Yes)
            {
                Game.CreateInstance(openFileDialog.FileName, this.pbGame.CreateGraphics);

                if (Visualisator.Instance != null)
                {
                    this.Attach(Visualisator.Instance);
                }
            }
        }

        /// <summary>
        /// метод считывания клика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbGame_Click(object sender, EventArgs e)
        {
            if (!IsWithingField(x, y))
            {
                return;
            }

            var cell = GetClickedCell(x, y);
            playerAdapter.Click(cell);
        }

        /// <summary>
        /// метод проверки, что кликнули в пределах поля
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool IsWithingField(int x, int y)
        {
            var borderWidth = (int)Settings.Default["FrameWidth"];
            return x >= borderWidth && x <= 340 && y >= borderWidth && y <= 340;
        }

        /// <summary>
        /// метод получения координат клетки, на которую кликнули
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Point GetClickedCell(int x, int y)
        {
            var borderWidth = (int)Settings.Default["FrameWidth"];
            var cellWidth = (int)Settings.Default["CellSideSize"];
            x = x - borderWidth;
            y = y - borderWidth;

            var cellX = x / cellWidth + 1;
            var cellY = y / cellWidth + 1;

            return new Point(cellX, cellY);
        }

        private void pbGame_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
    }
}
