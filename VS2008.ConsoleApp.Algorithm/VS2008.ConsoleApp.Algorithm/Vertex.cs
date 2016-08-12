using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace VS2008.ConsoleApp.Algorithm
{
    [JsonObject(MemberSerialization.OptOut)]
    public sealed class Vertex
    {
        public int count;
        public VPoint[] Coordinates;
        public double[,] Edge;

        public bool[,] HasTraversed;//在FR算法中，表示是否已经计算偏移量
    }
    [JsonObject(MemberSerialization.OptOut)]
    public class VPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double DispX { get; set; }
        public double DispY { get; set; }
        public int Index;
        public int ClassID;
        public int FWCount;
        public int ParentClassID;
        public string ClassName;
    }
}
