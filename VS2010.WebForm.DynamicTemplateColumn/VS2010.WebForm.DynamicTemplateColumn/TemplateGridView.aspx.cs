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
    public partial class TemplateGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            string sql = "Select * from Products";
            GridView1.Columns.Add(DynamicColumns("ProductID", false));
            GridView1.Columns.Add(DynamicColumns("ProductName", true));
            GridView1.Columns.Add(DynamicColumns("SupplierID", true));
            GridView1.Columns.Add(DynamicColumns("CategoryID", true));

            GridView1.DataKeyNames =new string[]{"ProductID"};
            GridView1.DataSource = GetDataTable(sql);
            GridView1.DataBind();
        }
        protected TemplateField DynamicColumns(string column, bool isEditable)
        {
            TemplateField genericcolumn = new TemplateField();
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
