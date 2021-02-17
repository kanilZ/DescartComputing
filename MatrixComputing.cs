using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescartComputing
{
    public static class MatrixComputing
    {
        public static float[,] Multiply(float[,] coords, float[,] matrix)
        {
            float[,] res = new float[coords.GetLength(0),coords.GetLength(1)];

            if (coords.GetLength(1)!= matrix.GetLength(0))
            {
                return null;
            }
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < coords.GetLength(1); k++)
                    {                    
                            res[i, j] += coords[i, k] * matrix[k, j];
                    }
                }
               
            }
            
            return res;
        }
    }
}
