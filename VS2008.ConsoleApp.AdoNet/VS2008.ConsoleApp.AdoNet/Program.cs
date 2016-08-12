using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
namespace VS2008.ConsoleApp.AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
            { 
                //conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from products";
                //SqlDataReader dr = cmd.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds=new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds, "products1");
               
                //using (SqlTransaction tran = conn.BeginTransaction())
                //{
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.Connection = conn;
                //    cmd.Transaction = tran;
              
                //    //cmd.CommandText = "INSERT INTO suppliers(companyName) values('xiaofu')";
                //    //int rows = cmd.ExecuteNonQuery();
                   
                //    cmd.CommandText = "select * from products ";
                //    SqlDataAdapter da=new SqlDataAdapter(cmd);
                    
                //    DataTable ds=new DataTable();
                //    da.Fill(ds);
                //    if(ds.Rows.Count!=0)
                //    {
                //        object tt = ds.Rows[0]["CategoryID"];
                //    }
                //    tran.Commit();
                //}
              
                
            }
        }
    }
}
