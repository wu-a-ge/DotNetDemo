using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Algorithm
{

    public sealed class KK
    {
        private Vertex V;
        private double L0; //展示平面一条边的长度
        private double[,] dij;//每对顶点之间的最短路径
        private double[,] lij;//顶点pi和pj之间的理想长度lij
        private double[,] kij;//参数kij表示pj与pi之间的弹簧强度
        private double L;//L是展示平面中理想的一个单位长度，需要计算
        private double K;//K是一个常数，在物理系统中，K表示弹簧的弹性系数，当弹簧材料一定时，弹性系数就是固定值
        private bool[] finalPosition;//已经固定后的顶点为true，否则为false
        //private const double Epsilon7 = 1e-7; //浮点数相等比较的误差值
        private const double Epsilon6 = 1e-6f;//△m与此值比较大小,此值取的大小对最终结果位置影响不很大
        private const double Pow0 = 0.5f;//
        private const double Pow1 = 1.5f;//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <param name="L0"></param>
        /// <param name="K"></param>
        public KK(Vertex V, double L0, double K)
        {
            this.V = V;
            this.L0 = L0;
            this.K = K;
            finalPosition = new bool[V.Coordinates.Length];
            lij = new double[V.Coordinates.Length, V.Coordinates.Length];
            kij = new double[V.Coordinates.Length, V.Coordinates.Length];
        }

        /// <summary>
        /// 两个顶点vi和vj之间的距离dij被定义为vi和vj之间的最短路径的长度
        /// </summary>
        /// <returns></returns>
        public double[,] ComputeDij()
        {
            dij = Floyd.GetShortedPath(V.Edge);
            return dij;
        }
        /// <summary>
        /// 针对表达式(2)
        /// 粒子pi和pj之间的初始长度lij 为它们之间的理想长度，
        /// 长度lij被定义为:lij=L*dij
        /// 参数lij对称的，也就是说lij=lji
        /// </summary>
        /// <returns></returns>
        public double[,] ComputeLij()
        {
            ComputeL();
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                for (int j = i + 1; j < V.Coordinates.Length; j++)
                {
                    lij[i, j] = lij[j, i] = L * dij[i, j];
                }
            }
            return lij;
        }
        /// <summary>
        /// 针对表达式(4)
        /// 参数kij表示pj与pi之间的弹簧强度
        /// 参数kij是对称的，也就是说kij=kji
        /// </summary>
        public double[,] ComputeKij()
        {

            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                for (int j = i + 1; j < V.Coordinates.Length; j++)
                {
                    kij[i, j] = kij[j, i] = K / (dij[i, j] * dij[i, j]);
                }
            }
            return kij;
        }
        /// <summary>
        /// 针对表达式(3)
        /// L是展示平面中理想的一个单位长度，当一个展示空间是固定的的时候，
        /// 通过一个给定地图的直径可以很好的定义L
        /// L=L0/max(dij)
        /// </summary>
        /// <param name="L0">展示平面一条边</param>
        /// <returns></returns>
        private void ComputeL()
        {
            L = L0 / GetMaxWeights(dij);
        }
        /// <summary>
        /// 求某个点的∂E/∂Xm，针对表达式(7)
        /// </summary>
        /// <param name="m">顶点索引值</param>
        /// <returns></returns>
        public double ComputeEXm(int m)
        {
            double exm = 0.0f;
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                if (m != i)
                    exm += kij[m, i] * ((GetPointFromIndex(m).X - GetPointFromIndex(i).X) - ((lij[m, i] * (GetPointFromIndex(m).X - GetPointFromIndex(i).X)) / GetDistanceVertex(GetPointFromIndex(m), GetPointFromIndex(i), Pow0)));
            }
            return exm;
        }
        /// <summary>
        /// 求某个点的∂E/∂Ym ，针对表达式(8)
        /// </summary>
        /// <param name="m">顶点索引值</param>
        /// <returns></returns>
        public double ComputeEYm(int m)
        {
            double eym = 0.0f;
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                if (m != i)
                    eym += kij[m, i] * ((GetPointFromIndex(m).Y - GetPointFromIndex(i).Y) - ((lij[m, i] * (GetPointFromIndex(m).Y - GetPointFromIndex(i).Y)) / GetDistanceVertex(GetPointFromIndex(m), GetPointFromIndex(i), Pow0)));
            }
            return eym;
        }

        /// <summary>
        /// 计算某个点的△m,针对表达式(9)
        /// </summary>
        /// <param name="m">顶点索引值</param>
        /// <returns></returns>
        public double ComputeDeltaM(int m)
        {
            double deltaM = Math.Sqrt(Math.Pow(ComputeEXm(m), 2) + Math.Pow(ComputeEYm(m), 2));
            return deltaM;
        }
        /// <summary>
        /// 计算所有点的△m
        /// </summary>
        /// <returns></returns>
        private double[] ComputeDeltaMForAllPoint()
        {
            double[] deltaM = new double[V.Coordinates.Length];
            //所有点的初始deltam
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                //已经移动到最佳位置的不用计算
                if (!finalPosition[i])
                    deltaM[i] = ComputeDeltaM(i);
            }
            return deltaM;
        }
        /// <summary>
        /// 计算某个点∂2E/∂Xm2，针对表达式(13)
        /// </summary>
        /// <param name="m">顶点的索引值</param>
        /// <returns></returns>
        public double ComputeEXm2(int m)
        {
            double exm2 = 0.0;
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                if (m != i)
                    exm2 += kij[m, i] * (1 - ((lij[m, i] * Math.Pow((GetPointFromIndex(m).Y - GetPointFromIndex(i).Y), 2)) / GetDistanceVertex(GetPointFromIndex(m), GetPointFromIndex(i), Pow1)));
            }
            return exm2;
        }
        /// <summary>
        /// 计算某个点∂2E/∂Xm∂Ym=∂2E/∂Ym∂Xm，针对表达式(14,15)
        /// </summary>
        /// <param name="m">顶点的索引值</param>
        /// <returns></returns>
        public double ComputeEXmYm(int m)
        {
            double exmym = 0.0;
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                if (m != i)
                    exmym += (kij[m, i] * lij[m, i] * (GetPointFromIndex(m).X - GetPointFromIndex(i).X) * (GetPointFromIndex(m).Y - GetPointFromIndex(i).Y)) / GetDistanceVertex(GetPointFromIndex(m), GetPointFromIndex(i), Pow1);

            }
            return exmym;
        }
        /// <summary>
        /// 计算某个点∂2E/∂Ym2，针对表达式(16)
        /// </summary>
        /// <param name="m">顶点的索引值</param>
        /// <returns></returns>
        public double ComputeEYm2(int m)
        {
            double eym2 = 0.0;
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                if(m!=i)
                    eym2 += kij[m, i] * (1 - ((lij[m, i] * Math.Pow((GetPointFromIndex(m).X - GetPointFromIndex(i).X), 2)) / GetDistanceVertex(GetPointFromIndex(m), GetPointFromIndex(i),Pow1)));
            }
            return eym2;
        }

        /// <summary>
        /// 返回两个顶点横纵坐标差的平方之和(xm-xi)2+(ym-yi)2，再求其幂
        /// </summary>
        /// <param name="v1">第一个顶点坐标</param>
        /// <param name="v2">第二个顶点坐标</param>
        /// <param name="pow">幂</param>
        /// <returns></returns>
        private double GetDistanceVertex(VPoint v1, VPoint v2, double pow)
        {
            return Math.Pow(Math.Pow((v1.X - v2.X), 2) + Math.Pow((v1.Y - v2.Y), 2), pow);
        }
        /// <summary>
        /// 求了dij中的最大值
        /// </summary>
        /// <param name="weights">权值，也即每对顶点的最短路径</param>
        /// <returns></returns>
        private double GetMaxWeights(double[,] weights)
        {
            double max = 0.0;
            foreach (double w in weights)
            {
                if (w > max) max = w;
            }
            return max;
        }
        /// <summary>
        /// 查找最大的deltaM顶点的索引值
        /// </summary>
        /// <returns>返回具有最大deltaM的顶点的索引值</returns>
        private void GetMaxDeltaM(double[] deltaM, out int index)
        {
            index = 0;//默认第一个点
            double maxDeltaM = 0.0;
            for(int i=0;i<deltaM.Length;i++)
            {
                if (deltaM[i] > maxDeltaM)
                {
                    maxDeltaM = deltaM[i];
                    index = i;
                }
            }
           
        }
        /// <summary>
        /// 迭代计算每个顶点的坐标位置
        /// </summary>
        public VPoint[]  Start()
        {
            ComputeDij();
            ComputeLij();
            ComputeKij();
            //
            double[] deltaM = ComputeDeltaMForAllPoint();
            int index;
            GetMaxDeltaM(deltaM,out index);
            while (deltaM[index] > Epsilon6)
            {
                while (deltaM[index] > Epsilon6)
                {
                    GetPointFromIndex(index).X = GetPointFromIndex(index).X + GetMoveDeltaX(index);
                    GetPointFromIndex(index).Y = GetPointFromIndex(index).Y + GetMoveDeltaY(index);
                    //再一次计算当前顶点的deltaM
                    deltaM[index] = ComputeDeltaM(index);
                }
                finalPosition[index] = true;//index点已经移动到最佳位置
                //更新每个顶点的deltam值，已经找到的就不计算了
                deltaM = ComputeDeltaMForAllPoint();
                //查找下一个次最大的deltaM的值
                GetMaxDeltaM(deltaM,out index);
            }
            return V.Coordinates;
            
        }
        /// <summary>
        /// 顶点m的X坐标位移
        /// </summary>
        /// <returns></returns>
        private double GetMoveDeltaX(int m)
        {
            return (ComputeEXmYm(m) * ComputeEYm(m) - ComputeEYm2(m) * ComputeEXm(m)) / (ComputeEXm2(m) * ComputeEYm2(m) - Math.Pow(ComputeEXmYm(m), 2));
        }
        /// <summary>
        /// 顶点m的Y坐标位移
        /// </summary>
        /// <returns></returns>
        private double GetMoveDeltaY(int m)
        {
            return (ComputeEXmYm(m)*ComputeEXm(m)-ComputeEYm(m)*ComputeEXm2(m))/(ComputeEXm2(m)*ComputeEYm2(m)-Math.Pow(ComputeEXmYm(m),2));
        }
        /// <summary>
        /// 通过索引查找坐标点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private VPoint GetPointFromIndex(int index)
        {
            foreach (var item in V.Coordinates)
            {
                if (item.Index == index)
                    return item;
            }
            throw new ArgumentException("索引不存在index:"+index);
        }
    }
}
