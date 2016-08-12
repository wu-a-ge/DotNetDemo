using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VS2010.ConsoleApp.Test
{
   public  class Dijkstra
    {
        public const int length = 6;
        public static int noPath = 10000000;
        public static int MaxSize = 10000000;
        public static int[,] G = { { noPath, noPath, 10, noPath, 30, 100 }, { noPath, noPath, 5, noPath, noPath, noPath }, { noPath, noPath, noPath, 50, noPath, noPath }, { noPath, noPath, noPath, noPath, noPath, 10 }, { noPath, noPath, noPath, 20, noPath, 60 }, { noPath, noPath, noPath, noPath, noPath, noPath } };
        public static int[] prev = new int[length];//当前结点前一个结点
        /// <summary>
        /// 从某一源点出发，找到到某一结点的最短路径
        /// </summary>
        /// <param name="G"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public  static int getShortedPath(int[,] G, int start, int end)
        {
            bool[] found = new bool[length]; //表示找到起始结点与当前结点间的最短路径
            int min;   //最小距离临时变量
            int curNode = 0; //临时结点，记录当前正计算结点
            int[] weights = new int[length];
            //初始结点信息
            for (int v = 0; v < length; v++)
            {
                found[v] = false;
                weights[v] = G[start, v];
                if (weights[v] < MaxSize)
                    prev[v] = start;
            }
            weights[start] = 0;
            found[start] = true;
            //主循环
            for (int i = 1; i < length; i++)
            {
                min = MaxSize;
                for (int w = 0; w < length; w++)
                {
                    if (!found[w] && weights[w] < min)
                    {
                        curNode = w;
                        min = weights[w];
                    }
                }

                found[curNode] = true;

                for (int j = 0; j < length; j++)
                    if (!found[j] && min + G[curNode, j] < weights[j])
                    {
                        weights[j] = min + G[curNode, j];
                        prev[j] = curNode;
                    }

            }
            return weights[end];
        }
        /// <summary>
        /// 从某一源点出发，找到到所有结点的最短路径
        /// </summary>
        /// <param name="G"></param>
        /// <param name="start"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int[] getShortedPath(int[,] G, int start)
        {
            bool[] found = new bool[length]; //表示找到start结点与当前某个结点间的最短路径
            int min;  //最小距离临时变量
            int curNode = 0; //临时结点，记录当前正计算结点
            int[] weights = new int[length];//从start结点到某个结点的权值
            //初始结点信息
            for (int v = 0; v < length; v++)
            {
                found[v] = false;
                weights[v] = G[start, v];//取得权值
                //当前结点的权值小于最大值，说明此两个结点可达
                if (weights[v] < MaxSize)
                {
                    prev[v] = start;
                }

            }
            //初始化,start属于S集
            weights[start] = 0;//起始点权值为0
            found[start] = true;
            //主循环,控制趟数
            for (int i = 1; i < length; i++)
            {
                min = MaxSize;
                for (int w = 0; w < length; w++)
                {
                    if (!found[w] && weights[w] < min)
                    {
                        curNode = w;
                        min = weights[w];
                    }
                }
                //加入S集合
                found[curNode] = true;
                //更新当前最短路径及距离 ,j属于V-S集合
                for (int j = 0; j < length; j++)
                    if (!found[j] && (min + G[curNode, j] < weights[j]))
                    {
                        weights[j] = min + G[curNode, j];
                        prev[j] = curNode;
                    }

            }

            return weights;

        }

       /// <summary>
       /// 递归打印路径
       /// </summary>
       /// <param name="index"></param>
        //public static void PrintPath(int index,int start)
        //{
        //    int preIndex = prev[index];
        //    if (preIndex != -1)
        //    {
        //        PrintPath(preIndex, start);
        //    }
        //    Console.Write(preIndex+" ");
        //}
    }

}
