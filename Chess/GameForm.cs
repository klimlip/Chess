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
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, WhiteOnTop, g);
            myGame.Draw(g);
        }


        public void Draw(bool IDontKnowWhyThisIsNecessary)
        {
            g = CreateGraphics();
            myGame.Draw(g);
        }

        private void rbBlackOnTop_CheckedChanged(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, WhiteOnTop, g);
            
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
            Draw(true);
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            
            myGame.Draw(g);

        }

        private void rbWhiteOnTop_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
