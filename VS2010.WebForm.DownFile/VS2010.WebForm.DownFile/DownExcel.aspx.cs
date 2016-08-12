using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace VS2010.WebForm.DownFile
{
    public partial class DownExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=.;Initial Catalog=tydata;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                DataColumn dc;
                DataTable dt = new DataTable("Table1");
                dc = new DataColumn()
                {
                    ColumnName = "OperatorName",Caption="操作员",DataType=typeof(string)
                 };
                dt.Columns.Add(dc);
                dc = new DataColumn() { ColumnName = "OperatorRealName", Caption = "真实名", DataType = typeof(string) };
                dt.Columns.Add(dc);
                dc = new DataColumn() { ColumnName = "OperatorPassword", Caption = "操作员密码", DataType = typeof(string) };
                dt.Columns.Add(dc);
                dc = new DataColumn() { ColumnName = "OperatorID", Caption = "操作员ID", DataType = typeof(string) };
                dt.Columns.Add(dc);
                SqlDataAdapter da = new SqlDataAdapter("SELECT [OperatorName], [OperatorRealName], [OperatorID], [OperatorPassword] FROM [OperatorBasicInfo]",conn);
                da.Fill(dt);
                GridView gv = new GridView();
                gv.AutoGenerateColumns = false;
                BoundField bf = new BoundField();
                bf.DataField = "OperatorName";
                bf.HeaderText = "操作员";
                gv.Columns.Add(bf);
                bf = new BoundField() { DataField = "OperatorRealName", HeaderText = "操作员密码" };
                gv.Columns.Add(bf);

                gv.DataSource = dt;
                gv.DataBind();
                UtilityLib.WebHelper.ExportExcel.DataTableToExcel(dt, @"|DataDirectory|\test.xls");
                UtilityLib.WebHelper.HttpHelper.DownloadFile("bb.xls", Server.MapPath(@"~\App_Data\test.xls"));
                //UtilityLib.WebHelper.ExportExcel.DataTableToExcel(dt, Server.MapPath(@"~\App_Data\test.xls"));
                    
                    
            }
        }
    }
}