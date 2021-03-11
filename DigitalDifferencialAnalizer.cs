using System;
using System.Drawing;

namespace DescartComputing
{
    static class DigitalDifferencialAnalizer
    {
        static public void BuildLine(float x1, float x2, float y1, float y2, Graphics gs)
        {
            float d1 = Math.Abs(x2 - x1), d2 = Math.Abs(y2 - y1);
            float distance = d1 >= d2 ? d1 : d2;
            float dx = (x2 - x1) / distance;
            float dy = (y2 - y1) / distance;
            float i = 1.0f;

            float x = x1, y = y1;
            gs.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 1, 1);
            FillRect(x, y - 25, 25, 25, gs);
            while (i < distance)
            {
                if (i % 25 == 0)
                    FillRect(x, y - 25, 25, 25, gs);

                x = x + dx;
                y = y + dy;
                gs.FillRectangle(Brushes.Red, (int)Math.Round(x), (int)Math.Round(y), 1, 1);

                //FillRect(lastX , lastY - 25, 25, 25, gs);
                i++;
            }
        }

        static public void FillRect(float x, float y, float width, float height, Graphics gs)
        {
            gs.FillRectangle(Brushes.Red, x, y, width, height);
        }
    }
}
