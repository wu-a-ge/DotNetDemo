using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace VS2008.WebForm.Test
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void renderEmptyGridView(GridView EmptyGridView, string FieldNames)
        {
            //將GridView變成只有Header和Footer列，以及被隱藏的空白資料列
            DataTable dTable = new DataTable();
            char[] delimiterChars = { ',' };
            string[] colName = FieldNames.Split(delimiterChars);
            foreach (string myCol in colName)
            {
                DataColumn dColumn = new DataColumn(myCol.Trim());
                dTable.Columns.Add(dColumn);
            }
            DataRow dRow = dTable.NewRow();

            foreach (string myCol in colName)
            {
                dRow[myCol.Trim()] = DBNull.Value;
            }
            dTable.Rows.Add(dRow);

            EmptyGridView.DataSourceID = null;
            EmptyGridView.DataSource = dTable;
            EmptyGridView.DataBind();
            //EmptyGridView.Rows[0].Visible = false;
            EmptyGridView.FooterRow.Visible = true;
        }
        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                renderEmptyGridView(GridView1, "FLOW_UID, FLOW_CODE, FLOW_NAME, FLOW_TYPE");
            }

        }

        protected void GridView1_Load(object sender, EventArgs e)
        {
            //回復原本GridView的資料連結
            GridView1.DataSource = null;
            GridView1.DataSourceID = "SqlDataSource1";
            
        }

    }
}
