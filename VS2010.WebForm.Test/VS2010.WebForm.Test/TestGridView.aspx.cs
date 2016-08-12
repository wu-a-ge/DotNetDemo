using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace VS2010.WebForm.Test
{
    public partial class TestGridView : System.Web.UI.Page
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connect = WebConfigurationManager.ConnectionStrings
                ["NorthwindConnectionString"].ConnectionString;
            _connection = new SqlConnection(connect);
            _connection.Open();
            _command = new SqlCommand(
                "SELECT *  from Products", _connection);
            _reader=_command.ExecuteReader();
            Output.DataSource = _reader;
            Output.DataBind();
            Output.DataSource = _reader;
            Output.DataBind();
            //_reader.Close();
        }
    }
}