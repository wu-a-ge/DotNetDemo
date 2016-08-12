using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Algorithm
{
    /// <summary>
    /// FR算法是先以坐标中心圆点算了后再移动到第一象限去
    /// </summary>
    public class FR
    {
        private const double Epsilon6 = 1e-6;
        private const double NoPath = 100000;
        private double a;
        private double b;
        private Vertex V;
        private double K;//平衡系数，动态生成
        private int VertexCount;//顶点数
        private double T;//初始温度值，动态生成
        private double Area;//动态生成，显示区域面积

        private int MaxIteration;//最大迭代次数
        private double W;//显示区域的宽
        private double L;//显示区域的高
        private Stack<VPoint> outPoints = new Stack<VPoint>();//在椭圆外的点的集合
        private List<VPoint> onEclipsePoints = new List<VPoint>();//在椭圆上的点集合

        public FR(double? w, double? l, int? maxIteration, int vertexCount, Vertex V)
        {
            this.W = w == null ? 980 : (double)w;
            this.L = l == null ? 690 : (double)l;
            this.MaxIteration = maxIteration == null ? 50 : (int)maxIteration;
            this.VertexCount = vertexCount;
            this.V = V;
            Area = (double)(W * L);
            K = Math.Sqrt(Area / VertexCount);
            T = 0.1 * (double)W;
            //椭圆的长半轴，短半轴
            a = this.W / 2;
            b = this.L / 2;

        }
        /// <summary>
        /// 返回两个顶点之前的距离 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetDistance(VPoint vp, VPoint up)
        {
            return Math.Sqrt(Math.Pow(vp.X - up.X, 2) + Math.Pow(vp.Y - up.Y, 2));
        }
        /// <summary>
        /// 计算两个顶点之间的斥力
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetRepulsionForce(double d)
        {
            return Math.Pow(K, 2) / d;
        }
        /// <summary>
        /// 计算两个顶点之间的引力
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetAttractiveForce(double d)
        {
            return -Math.Pow(d, 2) / K;
        }
        /// <summary>
        /// 计算斥力的X坐标的偏移
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetDispXRepulsionForce(VPoint vp, VPoint up)
        {
            double d = GetDistance(vp, up);
            return ((vp.X - up.X) / d) * GetRepulsionForce(d);
        }
        /// <summary>
        /// 计算斥力的Y坐标的偏移
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetDispYRepulsionForce(VPoint vp, VPoint up)
        {
            double d = GetDistance(vp, up);
            return ((vp.Y - up.Y) / d) * GetRepulsionForce(d);
        }
        /// <summary>
        /// 计算引力的X坐标的偏移
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetDispXAttractiveForce(VPoint vp, VPoint up)
        {
            double d = GetDistance(vp, up);
            return ((vp.X - up.X) / d) * GetAttractiveForce(d);
        }
        /// <summary>
        /// 计算引力的Y坐标的偏移
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private double GetDispYAttractiveForce(VPoint vp, VPoint up)
        {
            double d = GetDistance(vp, up);
            return ((vp.Y - up.Y) / d) * GetAttractiveForce(d);
        }
        /// <summary>
        /// 迭代计算温度值
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private double GetCooling(double i, double preT)
        {
            return (1 - i / MaxIteration) * preT;
        }

        /// <summary>
        /// 初始化HasTraversed为false
        /// </summary>
        private void InitialFlag()
        {
            for (int v = 0; v < VertexCount; v++)
            {
                for (int u = 0; u < VertexCount; u++)
                {
                    V.HasTraversed[v, u] = V.HasTraversed[u, v] = false;
                }
            }
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
            throw new ArgumentException("索引不存在index:" + index);
        }
        /// <summary>
        /// 计算每个顶点的坐标位置
        /// </summary>
        /// <returns></returns>
        public VPoint[] Start()
        {
            for (int i = 1; i <= MaxIteration; i++)
            {
                InitialFlag();
                //计算斥力
                for (int v = 0; v < VertexCount; v++)
                {
                    VPoint pv = GetPointFromIndex(v);
                    //初始化时偏移必须为0
                    pv.DispX = 0;
                    pv.DispY = 0;
                    for (int u = 0; u < VertexCount; u++)
                    {
                        if (u != v)
                        {
                            VPoint pu = GetPointFromIndex(u);
                            pv.DispX += GetDispXRepulsionForce(pv, pu);
                            pv.DispY += GetDispYRepulsionForce(pv, pu);
                        }
                    }
                }
                //计算引力
                for (int v = 0; v < VertexCount; v++)
                {
                    for (int u = 0; u < VertexCount; u++)
                    {
                        if (v != u)
                            if (V.Edge[v, u] < NoPath && !V.HasTraversed[v, u] && !V.HasTraversed[u, v])
                            {
                                VPoint pv = GetPointFromIndex(v);
                                VPoint pu = GetPointFromIndex(u);
                                V.HasTraversed[v, u] = V.HasTraversed[u, v] = true;
                                pv.DispX += GetDispXAttractiveForce(pv, pu);
                                pv.DispY += GetDispYAttractiveForce(pv, pu);
                                pu.DispX += GetDispXAttractiveForce(pu, pv);
                                pu.DispY += GetDispYAttractiveForce(pu, pv);
                            }
                    }
                }
                for (int j = 0; j < VertexCount; j++)
                {
                    VPoint pj = GetPointFromIndex(j);
                    VPoint oldP1 = new VPoint();
                    oldP1.X = pj.X;
                    oldP1.Y = pj.Y;
                    pj.X += Math.Sign(pj.DispX) * Math.Min(Math.Abs(pj.DispX), T);
                    pj.Y += Math.Sign(pj.DispY) * Math.Min(Math.Abs(pj.DispY), T);
                    VPoint finalPoint = this.GetFinalPosition(oldP1, pj);
                    pj.X = finalPoint.X;
                    pj.Y = finalPoint.Y;
                }
                //FilterOutOfRange();
                T = GetCooling(i, T);
                if (Math.Abs(T - Epsilon6) < Epsilon6)
                    break;
            }
            //FilterOutOfRange();
            return V.Coordinates;
        }

        public VPoint GetFinalPosition(VPoint oldp, VPoint newp)
        {
            //判断坐标是否在椭圆范围内或椭圆上
            if (this.CoordinateInsideEllipse(newp) || this.CoordinateOnEllipse(newp))
            {
                return newp;
            }
        
            //跑出椭圆创建直线方程
            VPoint p0 = new VPoint();
            //直线方程和椭圆方程求之间的两个交点
            if (Math.Abs(oldp.X - newp.X) < FR.Epsilon6)
            {
                p0.X = oldp.X;//是一条垂直X轴的直线
                p0.Y = this.GetYCoordinate(oldp.X, Math.Sign(newp.Y));//新点的Y坐标的象限
              
            }
            else if (Math.Abs(oldp.Y - newp.Y) < FR.Epsilon6)
            {
                p0.Y = oldp.Y;//是一条垂直Y轴的直线
                p0.X = this.GetXCoordinate(oldp.Y, Math.Sign(newp.X));//新点的X坐标的象限
            }
            else
            {
                //采用斜截式//y=kx+p;
                var k = (oldp.Y - newp.Y) / (oldp.X - newp.X);//斜率
                var p = oldp.Y - k * oldp.X;//
                //求交点X坐标
                var x1 = (-2 * this.a * this.a * k * p + Math.Sqrt(Math.Pow(2 * this.a * this.a * k * p, 2) - 4 * (this.b * this.b + this.a * this.a * k * k) * (this.a * this.a * p * p - this.a * this.a * this.b * this.b))) / (2 * (this.b * this.b + this.a * this.a * k * k));
                var x2 = (-2 * this.a * this.a * k * p - Math.Sqrt(Math.Pow(2 * this.a * this.a * k * p, 2) - 4 * (this.b * this.b + this.a * this.a * k * k) * (this.a * this.a * p * p - this.a * this.a * this.b * this.b))) / (2 * (this.b * this.b + this.a * this.a * k * k));
                //肯定介于原坐标和新坐标的X值之间
                if ((oldp.X < x1 && x1 < newp.X) || (newp.X < x1 && x1 < oldp.X))
                {
                    p0.X = x1;
                    p0.Y = this.GetYCoordinate(x1, Math.Sign(newp.X));//符号如何取？
                }
                else
                {
                    p0.X = x2;
                    p0.Y = this.GetYCoordinate(x2, Math.Sign(newp.X));//符号如何取？
                }
            }
            //判断其它点是否和这个交点重叠，重叠就返回原来点的位置，否则返回某个交点
            foreach (var item in this.V.Coordinates)
            {
                //排除自己
                if (item.Index == newp.Index)
                    continue;
                //重叠了直接返回原始坐标点
                if (Math.Abs(p0.X - item.X) < FR.Epsilon6 && Math.Abs(p0.Y - item.Y) < FR.Epsilon6)
                {
                    return oldp;
                }

            }
            return p0;


        }
        /// <summary>
        /// 判断坐标是否在椭圆范围内
        /// </summary>
        /// <returns></returns>
        private bool CoordinateInsideEllipse(VPoint v)
        {
            return Math.Pow(v.X, 2) / (Math.Pow(this.a, 2)) + Math.Pow(v.Y, 2) / (Math.Pow(this.b, 2)) < 1;
        }
        /// <summary>
        /// 判断坐标是否在椭圆上
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool CoordinateOnEllipse(VPoint v)
        {
            return Math.Abs((Math.Pow(v.X, 2) / (Math.Pow(this.a, 2)) + Math.Pow(v.Y, 2) / (Math.Pow(this.b, 2))) - 1) < Epsilon6;
        }
        /// <summary>
        /// 根据X坐标值返回Y坐标值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="sign">返回的值的符号</param>
        /// <returns></returns>
        private double GetYCoordinate(double x, int sign)
        {
            return sign * Math.Sqrt(1 - Math.Pow(x, 2) / Math.Pow(W / 2, 2)) * L / 2;
        }
        /// <summary>
        /// 根据Y坐标值返回X坐标值
        /// </summary>
        /// <param name="y"></param>
        /// <param name="sign">返回的值的符号</param>
        /// <returns></returns>
        private double GetXCoordinate(double y, int sign)
        {
            return sign * Math.Sqrt(1 - Math.Pow(y, 2) / Math.Pow(L / 2, 2)) * W / 2;
        }
    }
}
