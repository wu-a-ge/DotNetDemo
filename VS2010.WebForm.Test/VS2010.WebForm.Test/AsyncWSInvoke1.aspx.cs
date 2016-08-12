using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace VS2010.WebForm.Test
{
    public partial class AsyncWSInvoke1 : System.Web.UI.Page
    {
        private WebReference.WebService1 _ws;
        private DataSet _ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Hook PreRenderComplete event for data binding
                this.PreRenderComplete +=
                    new EventHandler(Page_PreRenderComplete);

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
            _ws = new WebReference.WebService1();
            // Fix up URL for call to local VWD-hosted Web service
            _ws.Url = new Uri(Request.Url, "Pubs.asmx").ToString();
            _ws.UseDefaultCredentials = true;
            return _ws.GetTitlesAsync(cb, state);
        }

        void EndAsyncOperation(IAsyncResult ar)
        {
            _ds = _ws.EndGetTitles(ar);
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