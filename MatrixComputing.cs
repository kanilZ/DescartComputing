using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescartComputing
{
    public static class MatrixComputing
    {
        public static  List<float[,]> Multiply( List<float[,]> coords, float[,] matrix)
        {
            List<float[,]> res = new List<float[,]>();
            foreach (var item in coords)
            {
                float[,] resarr = new float[item.GetLength(0), item.GetLength(1)];

                if (item.GetLength(1) != matrix.GetLength(0))
                {
                    return null;
                }
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < item.GetLength(1); k++)
                        {
                            resarr[i, j] += item[i, k] * matrix[k, j];
                        }
                    }
                }
                res.Add(resarr);
            }
            return res;
        }
    }
}
