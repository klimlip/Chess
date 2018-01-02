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
    public partial class Choose_Figure : Form
    {
        public Choose_Figure()
        {
            InitializeComponent();
        }

        private void radioButton_Queen_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button_Queen_Click(object sender, EventArgs e)
        {
            GameField.field[GameField.newFigureX, GameField.newFigureY] = new Queen(GameField.newFigureX, GameField.newFigureY, GameField.newPlayer);
            Choose_Figure.ActiveForm.Close();

        }

        private void button_Knight_Click(object sender, EventArgs e)
        {
            GameField.field[GameField.newFigureX, GameField.newFigureY] = new Knight(GameField.newFigureX, GameField.newFigureY, GameField.newPlayer);
            Choose_Figure.ActiveForm.Close();

        }

        private void button_Bishop_Click(object sender, EventArgs e)
        {
            GameField.field[GameField.newFigureX, GameField.newFigureY] = new Bishop(GameField.newFigureX, GameField.newFigureY, GameField.newPlayer);
            Choose_Figure.ActiveForm.Close();

        }

        private void buttpn_Rook_Click(object sender, EventArgs e)
        {
            GameField.field[GameField.newFigureX, GameField.newFigureY] = new Rook(GameField.newFigureX, GameField.newFigureY, GameField.newPlayer);
            Choose_Figure.ActiveForm.Close();

        }
    }
}
