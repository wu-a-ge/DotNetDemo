using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace VS2008.ConsoleApp.Algorithm
{
    public  class DomainHighBY:AccessBaseInitialMatrix
    {
        private static string SqlCount = "select count(*) from ";
        public override Vertex GetVertexFromAccess(Vertex V, string filePath)
        {
            return V;
        }

        
    }
}
