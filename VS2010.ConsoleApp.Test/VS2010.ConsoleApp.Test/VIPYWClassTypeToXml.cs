using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace VS2010.ConsoleApp.Test
{
    class VIPYWClassTypeToXml
    {
        public static void WriteXml()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSIPub"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select ClassTypeID,ClassTypeName,ID,Express from ClassTypeInfo where parentclassTypeID=0 and id!=9999 order by id", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string temp = string.Empty;
                var classTypes = dr["Express"].ToString().Split('+') ;
                foreach (string classType in classTypes)
                {
                    temp += "[" + classType+"+";
                }
                dr["Express"] = temp.Remove(temp.Length - 1) ;
            }
            ds.WriteXml("ClassType.xml");
        }
    }
}
