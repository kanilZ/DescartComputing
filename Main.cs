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
        Input form;
        private float[,] coords;
        private float[,] matrix;
        private Matrix Transform = null, InverseTransform = null;
       // Graphics gs;
        Pen p1 = new Pen(Color.Black);
        private const float DrawingScale = 25;
        private float Wxmin, Wxmax, Wymin, Wymax;

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
            MatrixComputing.Multiply(coords, matrix);

        }
        private void DrawLine()
        {

        }
        private void picturePlot_Paint(object sender, PaintEventArgs e)
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

           // e.Graphics.DrawLine(thin_pen, coords[0,0], coords[0,1], coords[1,0], coords[1,1]);
        }
    }
}
