using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VS2008.ConsoleApp.Algorithm;
using System.IO;
namespace VS2008.WinForm.Algorithm
{
    public partial class Form1 : Form
    {
        private const int L0 = 490;
        private const int K = 1;//任何值无影
        public static int noPath = 100000;
        private Vertex V = new Vertex();
        public Form1()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "form1";
            this.BackColor = System.Drawing.Color.White;
        }
  
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //初始化关系矩阵
            V = AlgorithmHelper.InitialMatrix(@"E:\VIP\智立方\测试数据\智立方人物数据\ly_data_writer.asp");
            ShowFR();
            //ShowKK();
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Blue, 1.5f);
            var newPoints = new PointF[V.Coordinates.Length];
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                newPoints[i].X = (float)V.Coordinates[i].X;
                newPoints[i].Y = (float)V.Coordinates[i].Y;
                //g.DrawPolygon(p, newPoints);
                g.DrawRectangle(p, newPoints[i].X, newPoints[i].Y, 4, 4);
                g.DrawString("A" + (i + 1), new Font("Arial", 10), new SolidBrush(Color.Red), newPoints[i].X + 5, newPoints[i].Y + 5);
            }
            for (int i = 0; i < V.Coordinates.Length; i++)
            {
                for (int j = i + 1; j < V.Coordinates.Length; j++)
                {
                    if (V.Edge[i, j] < noPath)
                        g.DrawLine(p, newPoints[i], newPoints[j]);
                }
            }
            //画椭圆
            //g.DrawEllipse(p, 0, 0, 980, 690);

            JSON.WriteJSONFile(V);
         
        }
 
        private void ShowKK()
        {
            var moved = true;
            //初始化顶点坐标
            V = AlgorithmHelper.InitialPolygonCoordinate(V, V.Edge.GetLength(0), moved);
            var kk=new  KK(V, L0, K);
            kk.Start();
            //移动坐标到第一象限
            if (!moved)
            {
                AlgorithmHelper.MoveCoordinate(V, 980 / 2, 690 / 2);
            }
        }
        private void ShowFR()
        {
            var width = 980;
            var height = 690;
            var moved = false;
            //初始化顶点坐标
            V = AlgorithmHelper.InitialPolygonCoordinate(V, V.Edge.GetLength(0), moved);
            var fr = new FR(width, height, null, V.Coordinates.Length, V);
            fr.Start();
            //移动坐标到第一象限
            if (!moved)
            {
                AlgorithmHelper.MoveCoordinate(V, width / 2, height / 2);
            }
        }
    }
}
