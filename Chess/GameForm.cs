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
        public GameForm()
        {
            InitializeComponent();
        }

        Graphics g;
        GameField gameField = new GameField();
        Painter p = new Painter();
        public void Draw(bool IDontKnowWhyThisIsNecessary)
        {
            g = CreateGraphics();
            //Painter p = new Painter();
            //GameField gameField = new GameField();
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            gameField.NewGame(firstIsHuman, secondIsHuman, WhiteOnTop);
            //Rectangle re = new Rectangle(0, 0, 256, 256);
            p.Draw(g, GameField.field);
        }

        private void rbBlackOnTop_CheckedChanged(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            gameField.NewGame(firstIsHuman, secondIsHuman, WhiteOnTop);
            p.Draw(g, GameField.field);
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
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            gameField.NewGame(firstIsHuman, secondIsHuman, WhiteOnTop);
            p.Draw(g, GameField.field);
        }
    }
}
