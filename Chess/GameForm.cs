using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class GameForm : Form
    {
        Graphics g;
        Game myGame;

        public GameForm()
        {
            InitializeComponent();
            g = CreateGraphics();
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, g);
        }


        public void Draw(bool IDontKnowWhyThisIsNecessary)
        {
            if (IDontKnowWhyThisIsNecessary)
            {
                g = CreateGraphics();
                myGame.Draw(g);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            myGame.Draw(e.Graphics);
            //Draw(true);
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman,g);
            g = CreateGraphics();
            //myGame.Draw(g);
            this.Invalidate();
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            string s = "";
            if (((Game.isWhitesTurn && rbPlayer1IsHuman.Checked) || (!Game.isWhitesTurn && rbPlayer2IsHuman.Checked)) && e.Button == MouseButtons.Left)
            {
                var point = GameField.PointFromForm(e.Location);
                IFigure b = myGame.FirstPartOfStep(point, ref s);
                foreach (var f in GameField.field)
                    if (f != null)
                        f.IsChosen = false;
                if( b != null)
                    b.IsChosen = true;
                this.Invalidate();

                //Draw(true);
            }
            if (e.Button == MouseButtons.Right)
            {
                var point = GameField.PointFromForm(new Point(e.X, e.Y));
                IFigure b = myGame.SecondPartOfStep(point, g, ref s);
                if(b!= null)
                    b.IsChosen = false;
                this.Invalidate();
                //Draw(true);
            }
            if (s != "")
                MessageBox.Show(s);
        }

        //Painter.WhereCanFigureGo(g, GameField.field[b.X, b.Y]);
   

        private void rbWhiteOnTop_CheckedChanged(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, g);
            this.Invalidate();

            //myGame.Draw(g);
        }

        private void button_CompGo_Click(object sender, EventArgs e)
        {
            g = CreateGraphics();
            bool firstPlayerIsComp = false, secondPlayerIsComp = false;
            if (rbPlayer1IsComputer.Checked)
                firstPlayerIsComp = true;
            if (rbPlayer2IsComputer.Checked)
                secondPlayerIsComp = true;
            myGame.ComputerDoStep(g, firstPlayerIsComp, secondPlayerIsComp);
        }
    }
}
