using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace VS2010.WebForm.Test
{
    public partial class AsyncDataBind : System.Web.UI.Page
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hook PreRenderComplete event for data binding
                //必须去掉这段代码，会被触发两次，GRIDVIEW控件绑定两次居然不会显示数据
                //this.PreRenderComplete +=
                //    new EventHandler(Page_PreRenderComplete);

                // Register async methods
                AddOnPreRenderCompleteAsync(
                    new BeginEventHandler(BeginAsyncOperation),
                    new EndEventHandler(EndAsyncOperation)
                );
            }
        }
        IAsyncResult BeginAsyncOperation(object sender, EventArgs e,
            AsyncCallback cb, object state)
        {
            string connect = WebConfigurationManager.ConnectionStrings
                ["NorthwindConnectionString"].ConnectionString;
            _connection = new SqlConnection(connect);
            _connection.Open();
            _command = new SqlCommand(
                "SELECT *  from Products", _connection);
            return _command.BeginExecuteReader(cb, state);
        }

        void EndAsyncOperation(IAsyncResult ar)
        {
            _reader = _command.EndExecuteReader(ar);
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Output.DataSource = _reader;
            Output.DataBind();
            //Output.DataSource = _reader;
            //Output.DataBind();
        }

        public override void Dispose()
        {
            if (_connection != null) _connection.Close();
            base.Dispose();
        }
    }
}