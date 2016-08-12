using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Test
{
    public class Floyd
    {
        public static int noPath = 10000000;
        public static int MIN = 0;
        public static int[,] spot = null;// 定义任意两点之间经过的点
        public static int[] onePath = null;// 记录一条路径
        public static int[,] weights = null;// 任意两点之间路径长度
        //int[][][] path = null;// 任意两点之间的路径
        public static int[,] G = { { 0, 4, 11 }, { 6, 0, 2 }, { 3, noPath, 0 }};
        public Floyd(int[,] G)
        {

            int row = G.Rank+1;// 图G的行数
            weights = new int[row, row];
            spot = new int[row, row];// 定义任意两点之间经过的点
            onePath = new int[row];// 记录一条路径
            //path = new int[row][];
            for (int i = 0; i < row; i++)
                // 初始化为任意两点之间没有路径
                for (int j = 0; j < row; j++)
                    spot[i, j] = -1;
            for (int i = 0; i < row; i++)
                // 假设任意两点之间的没有路径
                onePath[i] = -1;
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
           


        }
    }


}
