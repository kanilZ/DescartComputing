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
            //result = MatrixComputing.Multiply(coords, matrix);

        }
        private float[,] Make3D(float[,] coords)
        {
            var array3D = new float[coords.GetLength(0),2];
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                Convert3Dto2D(coords[i, 0], coords[i, 1], coords[i, 2],out array3D[i, 0],out array3D[i, 1]);
            }
            return array3D;
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

        private void Convert3Dto2D(float x, float y, float z, out float newX, out float newY)
        {
            newX = (float)(x - z * Math.Sin(Math.PI / 4));
            newY = (float)(y - z * Math.Sin(Math.PI / 4));
        }

        private void button3d_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < coords.Count; i++)
            {
                if (coords[i].Length == 2)
                {
                    DrawLine(coords[i], result[i]);
                }
                else
                {
                    DrawLines(Make3D(coords[i]));
                    DrawLines(coords[i]);
                  //  DrawLines(result[i]);
                }
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
            float tic = 0.2f;
            thin_pen.Width = 2 / DrawingScale;
            e.Graphics.DrawLine(thin_pen, Wxmin, 0, Wxmax, 0);
            for (int x = (int)Wxmin; x <= Wxmax; x++)
                e.Graphics.DrawLine(thin_pen, x, -tic, x, tic);
            e.Graphics.DrawLine(thin_pen, 0, Wymin, 0, Wymax);
            for (int y = (int)Wymin; y <= Wymax; y++)
                e.Graphics.DrawLine(thin_pen, -tic, y, tic, y);

            float zx1, zx2, zy1, zy2;
            float zd = (float)Math.Sqrt(2) * Wymin;
            Convert3Dto2D(0, 0, zd, out zx1, out zy1);
            Convert3Dto2D(0, 0, -zd, out zx2, out zy2);

            e.Graphics.DrawLine(thin_pen, zx1,-zy1, zx2, -zy2);
            for (int z = (int)zd; z <= -zd; z++)
            {
                float x, y;
                Convert3Dto2D(0, 0, z, out x, out y);
                e.Graphics.DrawLine(thin_pen, x+tic, -y, x-tic, -y);
            }
        }
    }
}
