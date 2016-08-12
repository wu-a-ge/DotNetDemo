using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace VS2010.WebForm.Test
{
    public partial class AsyncWSInvoke2 : System.Web.UI.Page
    {
        private WS.WebService1 _ws;
        private DataSet _ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hook PreRenderComplete event for data binding
                this.PreRenderComplete +=
                    new EventHandler(Page_PreRenderComplete);

                // Call the Web service asynchronously
                _ws = new WS.WebService1();
                _ws.GetTitlesCompleted += new
                    WS.GetTitlesCompletedEventHandler(GetTitlesCompleted);
                _ws.Url ="http://localhost:2433/WebService1.asmx";
                _ws.UseDefaultCredentials = true;
                _ws.GetTitlesAsync();
            }
        }

        void GetTitlesCompleted(Object source,
            WS.GetTitlesCompletedEventArgs e)
        {
            
            _ds = e.Result;
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Output.DataSource = _ds;
            Output.DataBind();
        }

        public override void Dispose()
        {
            if (_ws != null) _ws.Dispose();
            base.Dispose();
        }
    }
}