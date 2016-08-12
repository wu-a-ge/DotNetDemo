using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
namespace VS2010.WebForm.TestSqlCacheDependency
{
    public partial class Sql2005QueryCommand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataTable dt = HttpContext.Current.Cache["dt"] as DataTable;
            if (dt == null)
            {
                var tuple = GetData();
                HttpContext.Current.Cache.Insert("dt", tuple.Item1, tuple.Item2, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, UpdateCacheDatas);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private Tuple<DataTable, SqlCacheDependency> GetData()
        {
            using (
                SqlConnection sqlCon =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcachetest"].ConnectionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT id,name FROM dbo.test";
                //sqlCmd.CommandText = "SELECT CustomerID,CompanyName,ContactName,ContactTitle,Address FROM dbo.Customers";
                SqlCacheDependency scd = new SqlCacheDependency(sqlCmd);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                var dt = new DataTable();
                sda.Fill(dt);
                return Tuple.Create(dt, scd);
            }
        }


        private  void UpdateCacheDatas(string key, CacheItemUpdateReason reason, out object expensiveObject,
                                     out CacheDependency dependency, out DateTime absoluteExpiration,
                                     out TimeSpan slidingExpiration)
        {

            var tuple = GetData();
            expensiveObject = tuple.Item1;
            dependency =tuple.Item2 ;
            absoluteExpiration = Cache.NoAbsoluteExpiration;
            slidingExpiration = Cache.NoSlidingExpiration;
        }

         
    }
}