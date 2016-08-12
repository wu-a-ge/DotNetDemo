using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
namespace VS2010.ConsoleApp.ForTestAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var conn=new OleDbConnection(ConfigurationManager.AppSettings["connection"]))
                {
                    OleDbCommand cmd = new OleDbCommand("select count(*) from ELMAH_Error ");
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                   var tt=  cmd.ExecuteScalar();
                    Console.WriteLine(tt);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
                
            }
            Console.Read();
        }
    }
}
