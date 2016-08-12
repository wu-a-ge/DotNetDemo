using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace VS2010.WebForm.DynamicTemplateColumn
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            string sql = "Select * from Products";
            DataGrid dg = new DataGrid();
            DataGrid1.Columns.Add(DynamicColumns("ProductID", false));
            DataGrid1.Columns.Add(DynamicColumns("ProductName", true));
            DataGrid1.Columns.Add(DynamicColumns("SupplierID", true));
            DataGrid1.Columns.Add(DynamicColumns("CategoryID", true));

            DataGrid1.DataKeyField = "ProductID";
            DataGrid1.DataSource = GetDataTable(sql);
            DataGrid1.DataBind();
        }
        protected TemplateColumn DynamicColumns(string column, bool isEditable)
        {
            TemplateColumn genericcolumn = new TemplateColumn();
            genericcolumn.HeaderText = column;
            genericcolumn.ItemTemplate = new GenericField(column);
            if (isEditable)
            {
                genericcolumn.EditItemTemplate = new ValidateEditItem(column);
            }
            return genericcolumn;
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            string connection = "Data Source=THINK-THINK;Initial Catalog=Northwind;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql,conn);
               
                da.Fill(dt);
                
            }
            return dt;
        }


    }
}