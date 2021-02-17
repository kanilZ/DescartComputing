using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DescartComputing
{
    public partial class Input : Form
    {
        public float[,] Coords { get; private set; }
        public float[,] Matrix { get; private set; }
       
        public Input()
        {
            InitializeComponent();
            ChangeMask();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Coords = FormArray(dataGridCoords.Rows.Count-1, dataGridCoords.Columns.Count, dataGridCoords);
            Matrix = FormArray(dataGridMatrix.Rows.Count-1, dataGridMatrix.Columns.Count, dataGridMatrix);
            Close();
        }
        private float[,] FormArray(int row, int colm, DataGridView dataGrid)
        {
        
            float[,] res = new float[row, colm];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < colm; j++)
                {
                    res[i, j] = Convert.ToInt32(dataGrid.Rows[i].Cells[j].Value);
                }
            }
            return res;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridMatrix.Columns.Clear();
            ChangeMask();
        }

        private void ChangeMask()
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                dataGridMatrix.Columns.Add("{i+1}", "|");
                dataGridMatrix.Columns[i].Width = 30;
            }
        }
        private void dataGridCoords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
