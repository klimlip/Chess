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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;

        public void Draw(bool IDontKnowWhyThisIsNecessary)
        {
            g = this.CreateGraphics();
            Painter p = new Painter();
            //Rectangle re = new Rectangle(0, 0, 256, 256);
            p.Drow(g);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(true);
        }
    }
}
