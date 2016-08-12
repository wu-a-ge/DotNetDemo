using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace VS2008.ConsoleApp.Algorithm
{
    public class DomainToDomain:AccessBaseInitialMatrix
    {
        public override Vertex GetVertexFromAccess(Vertex V, string filePath)
        {
            int length = 35;
            V.HasTraversed = new bool[length, length];
            V.Coordinates = new VPoint[length];
            V.Edge = new double[length, length];
            using (OleDbConnection conn = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", filePath)))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select cosine  from class_class_fst ";
                    using (OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        int i = 0, j = 0;
                        while (dr.Read())
                        {
                            V.Edge[i, j] = dr.GetDouble(0);
                            if (i != j && V.Edge[i, j] < Epsilon7)
                            {
                                V.Edge[i, j] = noPath;
                            }
                            j++;
                            //下一分类
                            if (j == 35)
                            {
                                i++;
                                j = 0;
                            }

                        }
                    }
                }
            }
            return V;
        }
    }
}
