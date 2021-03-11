using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DescartComputing
{
    static class Brezenhem
    {
        static public void BuildLine(float x1, float x2, float y1, float y2, Graphics gs, PictureBox picture)
        {

            float dx = (x2 - x1 >= 0 ? 1 : -1);
            float dy = (y2 - y1 >= 0 ? 1 : -1);

            float lengthX = Math.Abs(x2 - x1);
            float lengthY = Math.Abs(y2 - y1);

            float length = Math.Max(lengthX, lengthY);

            if (length == 0)
            {

                gs.FillRectangle(Brushes.Black, x1, y1, 1, 1);
                DrawRectPoint(x1, y1, gs, picture);
            }

            if (lengthY <= lengthX)
            {

                float x = x1;
                float y = y1;
                float d = -lengthX;


                length++;
                while (length != 0)
                {
                    gs.FillRectangle(Brushes.Black, x, y, 1, 1);
                    DrawRectPoint(x, y, gs, picture);
                    x += dx;
                    d += 2 * lengthY;
                    if (d > 0)
                    {
                        d -= 2 * lengthX;
                        y += dy;
                    }
                    length--;
                }
            }
            else
            {

                float x = x1;
                float y = y1;
                float d = -lengthY;

                length++;

                while (length != 0)
                {
                    gs.FillRectangle(Brushes.Black, x, y, 1, 1);
                    DrawRectPoint(x, y, gs, picture);
                    y += dy;
                    d += 2 * lengthX;
                    if (d > 0)
                    {
                        d -= 2 * lengthY;
                        x += dx;
                    }
                    length--;
                }
            }
        }
        static private void DrawRectPoint(float x, float y, Graphics gs, PictureBox picture)
        {
            float x1 = ConvertX(x, picture.ClientSize.Width);
            float y1 = ConvertY(y, picture.ClientSize.Height);
            if (y < picture.ClientSize.Height/2)
            {
                DigitalDifferencialAnalizer.FillRect(x1, y1 - 25, 25, 25, gs);
            }
            else
            {
                DigitalDifferencialAnalizer.FillRect(x1, y1 + 25, 25, 25, gs);
            }
        }
        static private float ConvertX(float x, int width)
        {
            int buf = (int)((x - width / 2) / Form1.DrawingScale);
            return buf * Form1.DrawingScale + width / 2;
        }
        static private float ConvertY(float y, int height)
        {
            int buf = (int)((y - height / 2) / Form1.DrawingScale);
            return buf * Form1.DrawingScale + height / 2;
        }
        static private int Sign(float x)
        {
            return (x > 0) ? 1 : (x < 0) ? -1 : 0;
        }
    }
}
