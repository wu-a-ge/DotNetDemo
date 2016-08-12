using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2008.ConsoleApp.Algorithm
{
    public   abstract class AccessBaseInitialMatrix:IInitialMatrix
    {
        protected const double Epsilon7 = 1e-7f;
        protected const int noPath = 10000000;
        protected static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};";

        public abstract Vertex GetVertexFromAccess(Vertex V, string filePath);

    }
}
