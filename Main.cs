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
    public partial class Form1 : Form
    {
        Graphics gs;
        Input form;
        public List<float[,]> coords;
        private float[,] matrix;
        public List<float[,]> result;
        private Matrix Transform = null, InverseTransform = null;
        private const float DrawingScale = 25;
        private float Wxmin, Wxmax, Wymin, Wymax;
        Pen p1 = new Pen(Color.Black, 3);


        private void Form1_Resize(object sender, EventArgs e)
        {
            CreateTransforms();
            picturePlot.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
            form = new Input();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                if (coords[i].Length == 2)
                {
                    DrawLine(coords[i], result[i]);
                }
                else
                {
                    DrawLines(coords[i]);
                    DrawLines(result[i]);
                }
                
            }

        }

        private void CreateTransforms()
        {
            Transform = new Matrix();
            Transform.Scale(DrawingScale, DrawingScale);
            float cx = picturePlot.ClientSize.Width / 2;
            float cy = picturePlot.ClientSize.Height / 2;
            Transform.Translate(cx, cy, MatrixOrder.Append);

            // Make the inverse transformation. (Device --> World)
            InverseTransform = Transform.Clone();
            InverseTransform.Invert();

            // Calculate the world coordinate bounds.
            Wxmin = -cx / DrawingScale;
            Wxmax = cx / DrawingScale;
            Wymin = -cy / DrawingScale;
            Wymax = cy / DrawingScale;
        }
        private void inputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.ShowDialog();
            coords = form.Coords;
            matrix = form.Matrix;
            if (coords == null || matrix == null)
                return;

            if (checkBox1.Checked)
            {
                MirrorCoords();
            }
            result = MatrixComputing.Multiply(coords, matrix);

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            gs = picturePlot.CreateGraphics();
            gs.Clear(Color.White);
            picturePlot.Refresh();
        }


        private void DrawLine(float[,] coords, float[,] result)
        {
            float x1 = ScaleCoords(coords[0, 0], picturePlot.ClientSize.Width), y1 = ScaleCoords(coords[0, 1], picturePlot.ClientSize.Height),
           x2 = ScaleCoords(result[0, 0], picturePlot.ClientSize.Width), y2 = ScaleCoords(result[0, 1], picturePlot.ClientSize.Height);
            gs.DrawLine(p1, x1, y1, x2, y2);
        }
        private void DrawLines(float[,] coords)
        {
            float x1, x2, y1, y2;
            gs = picturePlot.CreateGraphics();

            //if (item.Length == 2)
            //{
            //    x1 = ScaleCoords(item[0, 0], picturePlot.ClientSize.Width); y1 = ScaleCoords(item[0, 1], picturePlot.ClientSize.Height);
            //    x2 = ScaleCoords(result.IndexOf(item), picturePlot.ClientSize.Width); y2 = ScaleCoords(result.IndexOf(item), picturePlot.ClientSize.Height); ;
            //    gs.DrawLine(p1, x1, y1, x2, y2);
            //    continue;
            //}

            x1 = ScaleCoords(coords[0, 0], picturePlot.ClientSize.Width); y1 = ScaleCoords(coords[0, 1], picturePlot.ClientSize.Height);
            x2 = ScaleCoords(coords[coords.GetLength(0) - 1, 0], picturePlot.ClientSize.Width); y2 = ScaleCoords(coords[coords.GetLength(0) - 1, 1], picturePlot.ClientSize.Height);
            gs.DrawLine(p1, x1, y1, x2, y2);

            for (int i = 0; i < coords.GetLength(0) - 1; i++)
            {
                x1 = ScaleCoords(coords[i, 0], picturePlot.ClientSize.Width); y1 = ScaleCoords(coords[i, 1], picturePlot.ClientSize.Height);
                x2 = ScaleCoords(coords[i + 1, 0], picturePlot.ClientSize.Width); y2 = ScaleCoords(coords[i + 1, 1], picturePlot.ClientSize.Height);

                gs.DrawLine(p1, x1, y1, x2, y2);
            }

        }

    

        private void MirrorCoords()
        {
            float[,] mirrorMask = { { 1, 0 }, { 0, -1 } };
            coords = MatrixComputing.Multiply(coords, mirrorMask);
        }
        private float ScaleCoords(float coord, int clientSize)
        {
            return coord * DrawingScale + clientSize / 2;
        }
        private void picturePlot_Paint(object sender, PaintEventArgs e)
        {
            DrawAxis(sender, e);
        }

        private void DrawAxis(object sender, PaintEventArgs e)
        {
            if (Transform == null) CreateTransforms();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Transform = Transform;
            Pen thin_pen = new Pen(Color.Black, 0);
            float tic = 0.1f;
            thin_pen.Width = 2 / DrawingScale;
            e.Graphics.DrawLine(thin_pen, Wxmin, 0, Wxmax, 0);
            for (int x = (int)Wxmin; x <= Wxmax; x++)
                e.Graphics.DrawLine(thin_pen, x, -tic, x, tic);
            e.Graphics.DrawLine(thin_pen, 0, Wymin, 0, Wymax);
            for (int y = (int)Wymin; y <= Wymax; y++)
                e.Graphics.DrawLine(thin_pen, -tic, y, tic, y);
        }
    }
}
