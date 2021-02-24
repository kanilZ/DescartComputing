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
        public List<float[,]> Coords { get; private set; }
        public float[,] Matrix { get; private set; }

        public Input()
        {
            InitializeComponent();
            ChangeMask();
            InitDataGrid();
        }
        private void InitDataGrid()
        {
            /* 
             0	0	0	1
             2	0	0	1
             2	0	2	1
             0	0	2	1
             0	0	0	1
             0	2	0	1
             2	2	0	1
             2	0	0	1
             0	0	0	1
             0	2	0	1
             0	2	2	1
             2	2	2	1
             2	2	0	1
             0	2	0	1
             0	2	2	1
             0	0	2	1
             2	0	2	1
             2	2	2	1
             0	2	2	1

            */
            dataGridCoords.Rows.Add();
            dataGridCoords.Rows.Add();
            dataGridCoords.Rows.Add();
            dataGridCoords.Rows.Add();
            dataGridCoords.Rows.Add();
            dataGridCoords.Rows.Add();

            dataGridCoords.Rows[0].Cells[0].Value = "1";
            dataGridCoords.Rows[0].Cells[1].Value = "1";
            dataGridCoords.Rows[1].Cells[0].Value = "3";
            dataGridCoords.Rows[1].Cells[1].Value = "1";
            dataGridCoords.Rows[2].Cells[0].Value = "1";
            dataGridCoords.Rows[2].Cells[1].Value = "3";

            dataGridMatrix.Rows.Add();
            dataGridMatrix.Rows.Add();
            dataGridMatrix.Rows[0].Cells[0].Value = "3";
            dataGridMatrix.Rows[0].Cells[1].Value = "0";
            dataGridMatrix.Rows[1].Cells[0].Value = "0";
            dataGridMatrix.Rows[1].Cells[1].Value = "3";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Coords = new List<float[,]>();
            int colm = (int)numericUpDownXY.Value;
            Coords.Add(FormArray(dataGridCoords.Rows.Count - 1, colm, dataGridCoords));
            Matrix = FormArray(dataGridMatrix.Rows.Count - 1, dataGridMatrix.Columns.Count, dataGridMatrix);
            Close();
        }

        private float[,] FormArray(int row, int colm, DataGridView dataGrid)
        {
            int it = 0;
            float[,] res = new float[row, colm];
            try
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < colm; j++)
                    {
                        if (!float.TryParse((string)dataGrid.Rows[i].Cells[j].Value, out res[i, j]))
                        {
                            Coords.Add(RewriteArray(res, it, i, colm));
                            it = i + 1;
                            break;
                        }

                    }
                }
                res = RewriteArray(res, it, row, colm);
            }
            catch (Exception)
            {
                return null;
            }
            return res;
        }
        T[,] RewriteArray<T>(T[,] original, int startRow, int endRow, int cols)
        {
            var newArray = new T[endRow - startRow, cols];
            for (int i = startRow, k = 0; i < endRow; i++, k++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newArray[k, j] = original[i, j];
                }
            }
            return newArray;
        }
        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
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


        private void numericUpDownXY_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownXY.Value == 2)
            {
                dataGridCoords.Columns["Z"].Visible = false;
                dataGridCoords.Columns["H"].Visible = false;

            }
            else if (numericUpDownXY.Value == 3)
            {
                dataGridCoords.Columns["Z"].Visible = true;
                dataGridCoords.Columns["H"].Visible = false;
            }
            else
            {
                dataGridCoords.Columns["H"].Visible = true;
            }
        }
    }
}
