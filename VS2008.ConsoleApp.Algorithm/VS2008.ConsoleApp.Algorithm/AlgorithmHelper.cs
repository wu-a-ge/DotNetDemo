using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
namespace VS2008.ConsoleApp.Algorithm
{
    public sealed class AlgorithmHelper
    {
        private const double Epsilon6 = 1e-6;
        private const int noPath = 100000;
        /// <summary>
        /// 初始化正多边形的各个顶点坐标
        /// </summary>
        /// <param name="V">Vertex对象</param>
        /// <param name="edgeNumbers">多边形的边数等于顶点数</param>
        /// <param name="r">外接圆的半径，默认大小245</param>
        /// <param name="x">多边形外接圆的中心x坐标，默认值490</param>
        /// <param name="y">多边形外接圆的中心y坐标,默认值345</param>
        /// <param name="moved">是否平移</param>
        /// <returns></returns>
        public static Vertex InitialPolygonCoordinate(Vertex V, int edgeNumbers, int? r, double? x, double? y, bool moved)
        {

            x = x ?? 490 ;
            y = y ?? 345 ;
            r = r??245;
            if (moved)
                for (int i = 1; i <= edgeNumbers; i++)
                {
                    V.Coordinates[i - 1] = new VPoint();
                    V.Coordinates[i - 1].Index = i - 1;
                    V.Coordinates[i - 1].X = (double)(Math.Cos(i * Math.PI * 2 / edgeNumbers) * r + x);
                    V.Coordinates[i - 1].Y = (double)(Math.Sin(i * Math.PI * 2 / edgeNumbers) * r + y);
                }
            else
                for (int i = 1; i <= edgeNumbers; i++)
                {
                    V.Coordinates[i - 1] = new VPoint();
                    V.Coordinates[i - 1].Index = i - 1;
                    V.Coordinates[i - 1].X = (double)(Math.Cos(i * Math.PI * 2 / edgeNumbers) * r);
                    V.Coordinates[i - 1].Y = (double)(Math.Sin(i * Math.PI * 2 / edgeNumbers) * r);
                }
            return V;
        }
        /// <summary>
        /// 初始化正多边形的各个顶点坐标
        /// </summary>
        /// <param name="V">Vertex对象</param>
        /// <param name="edgeNumbers">多边形的边数</param>
        /// <returns></returns>
        public static Vertex InitialPolygonCoordinate(Vertex V, int edgeNumbers, bool moved)
        {
            return InitialPolygonCoordinate(V, edgeNumbers, null, null, null, moved);
        }
        /// <summary>
        /// 初始化正多边形的各个顶点坐标
        /// </summary>
        /// <param name="V">Vertex对象</param>
        /// <param name="edgeNumbers">多边形的边数</param>
        /// <param name="r">外接圆的半径，默认大小245</param>
        /// <returns></returns>
        public static Vertex InitialPolygonCoordinate(Vertex V, int edgeNumbers, int r, bool moved)
        {
            return InitialPolygonCoordinate(V, edgeNumbers, r, null, null, moved);
        }
        /// <summary>
        /// 从文件读取矩阵信息
        /// </summary>
        /// <param name="V"></param>
        /// <returns></returns>
        public static Vertex InitialMatrix(Vertex V, string filePath)
        {

            StreamReader stream = new StreamReader(File.OpenRead(filePath));
            int i = 0, j = 0;
            //第一行是长度
            int length = int.Parse(stream.ReadLine());
            //分配空间
            V.HasTraversed = new bool[length, length];
            V.Coordinates = new VPoint[length];
            V.Edge = new double[length, length];
            for (int n = 0; n < length; n++)
            {
                V.Coordinates[n] = new VPoint();
            }
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                string[] columns = line.Split(' ');
                foreach (string column in columns)
                {
                    if (!string.IsNullOrEmpty(column))
                    {
                        V.Edge[i, j] = double.Parse(column);
                        if (i != j && V.Edge[i, j] < Epsilon6)
                        {
                            V.Edge[i, j] = noPath;
                        }
                        j++;
                    }
                }
                i++;
                j = 0;
            }
            stream.Close();
            return V;
        }
        /// <summary>
        /// 从文件读取JSON信息
        /// </summary>
        /// <param name="V"></param>
        /// <returns></returns>
        public static Vertex InitialMatrix(string filePath)
        {
            using (StreamReader stream = new StreamReader(File.OpenRead(filePath)))
            {
                var json = stream.ReadToEnd();
                var V = JToken.Parse(json).ToObject<Vertex>();
                V.HasTraversed = new bool[V.count,V.count];
                //for (int i = 0; i < V.count; i++)
                //{
                //    hashTable[V.Coordinates[i].Index] = V.Coordinates[i];
                //}
                return V;
            }
          
            
        }
        /// <summary>
        /// 移动坐标
        /// </summary>
        /// <param name="V"></param>
        public static void MoveCoordinate(Vertex V,int w,int h)
        {
            foreach (VPoint point in V.Coordinates)
            {
                point.X += w;
                point.Y += h;
            }
        }
    }
}
