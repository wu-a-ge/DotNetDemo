using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    public static class Floyd
    {
        //private static double noPath = 10000000;
        //private static double MIN = 0;

        public static int[,] spot = null;// 定义任意两点之间经过的点
        public static int[] onePath = null;// 记录一条路径
     
        /// <summary>
        /// 计算每对顶点之间的最短路径
        /// </summary>
        /// <param name="G"></param>
        /// <returns></returns>
        public static double[,] GetShortedPath(double[,] G)
        {
            int row = G.GetLength(0);// 图G的行数
            double[,] weights = new double[row, row];
            spot = new int[row, row];// 定义任意两点之间经过的点
            onePath = new int[row];// 记录一条路径
            for (int v = 0; v < row; ++v)
                for (int w = 0; w < row; ++w)
                    weights[v, w] = G[v, w];
            for (int u = 0; u < row; ++u)
                for (int v = 0; v < row; ++v)
                    for (int w = 0; w < row; ++w)
                        if (weights[v, w] > weights[v, u] + weights[u, w])
                        {
                            weights[v, w] = weights[v, u] + weights[u, w];// 如果存在更短路径则取更短路径
                            spot[v, w] = u;// 把经过的点加入
                        }
            return weights;
        }
    }
}
