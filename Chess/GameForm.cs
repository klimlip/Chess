﻿using System;
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
            Draw(true);
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, WhiteOnTop, g);
            myGame.Draw(g);
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {                
                if (e.Button == MouseButtons.Left)
                {
                    var point = GameField.PointFromForm(e.Location);
                    IFigure b = myGame.FirstPartOfStep(point);
                    foreach (var f in GameField.field)
                        if (f != null)
                            f.IsChosen = false;
                    b.IsChosen = true;
                    Draw(true);
                }
                if (e.Button == MouseButtons.Right)
                {
                    var point = GameField.PointFromForm(new Point(e.X, e.Y));
                    IFigure b = myGame.SecondPartOfStep(point, g);
                    b.IsChosen = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Painter.WhereCanFigureGo(g, GameField.field[b.X, b.Y]);
        }

        private void rbWhiteOnTop_CheckedChanged(object sender, EventArgs e)
        {
            bool firstIsHuman = rbPlayer1IsHuman.Checked, secondIsHuman = rbPlayer2IsHuman.Checked, WhiteOnTop = rbWhiteOnTop.Checked;
            myGame = new Game(firstIsHuman, secondIsHuman, WhiteOnTop, g);
            myGame.Draw(g);
        }
    }
}
