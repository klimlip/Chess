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

        public void Draw(bool IDontKnowWhyThisIsNecessary)
        {
            g = this.CreateGraphics();
            Painter p = new Painter();
            GameField gameFild = new GameField();
            gameFild.NewGame();
            //Rectangle re = new Rectangle(0, 0, 256, 256);
            p.Draw(g, GameField.figures);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(true);
        }
    }
}
