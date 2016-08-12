using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VS2008.ConsoleApp.Algorithm;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
namespace VS2008.ConsoleApp.TestAlgorithm
{
    class Program
    {
 
        static void Main(string[] args)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            ArrayList arrpoint = new ArrayList();
            List<int> listindex = new List<int>();
            double[,] medge;

            medge = new double[2, 2];
            medge[0, 0] = 1;
            medge[0, 1] = 2;
            medge[1, 0] = 3;
            medge[1, 1] = 4;
            dic.Add("count", 2);
            dic.Add("Edge", medge);
            Console.WriteLine(JsonConvert.SerializeObject(dic, Formatting.Indented));
            Console.Read();
            ////TestDijkstra();
            ////TestFloyd();
           
            ////TestDij();
            ////TestLij();
            ////TestKij();
            ////TestEXm();
            ////TestEYm();
            ////TestEXmYm();
            ////TestEXm2();
            ////TestEYm2();
            //Console.WriteLine(Math.Sqrt(5));
            //for (int i = 0; i < V.Coordinates.Length; i++)
            //{
            //    Console.WriteLine("顶点{0}的原始坐标为:({1},{2})",i,V.Coordinates[i].X,V.Coordinates[i].Y);
            //}
            //TestIterationCoordinate();
            //Console.ReadKey();
        }
        
        


    }
}
