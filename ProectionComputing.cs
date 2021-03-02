using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescartComputing
{
    static class ProectionComputing
    {
        static public List<float[,]> ComputeParallel(List<float[,]> coords, float distance)
        {
            List<float[,]> res = new List<float[,]>();
            foreach (var item in coords)
            {
                float[,] resarr = new float[item.GetLength(0), item.GetLength(1)];
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    resarr[i, 0] = (distance * item[i, 0]) / item[i, 2];
                    resarr[i, 1] = (distance * item[i, 1]) / item[i, 2];
                    resarr[i, 2] =  distance;
                }

                res.Add(resarr);
            }
            return res;
        }

        static public List<float[,]> ComputeKoso(List<float[,]> coords, float sina, float cosa,float l)
        {

            List<float[,]> res = new List<float[,]>();
            foreach (var item in coords)
            {
                float[,] resarr = new float[item.GetLength(0), item.GetLength(1)];
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    resarr[i, 0] = item[i,0] + l*item[i,2]*cosa;
                    resarr[i, 1] = item[i, 1] + l*item[i, 2] * sina;
                    resarr[i, 2] = 0;
                }

                res.Add(resarr);
            }
            return res;
        }
    }
}
