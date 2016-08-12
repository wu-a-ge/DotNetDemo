using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace VS2010.WebForm.DynamicTemplateColumn
{
        public class GenericField : ITemplate
        {
            private string columnName;
 
            public GenericField(string column)
            {
                this.columnName = column;
            }
            public void InstantiateIn(Control container)
            {
                Literal literal = new Literal();
                literal.DataBinding += new EventHandler(literal_DataBinding);
                container.Controls.Add(literal);
            }

            void literal_DataBinding(object sender, EventArgs e)
            {
                Literal literal = (Literal)sender;
                GridViewRow container = (GridViewRow)literal.NamingContainer;//就是找它的父控件，看Control源代码
                literal.Text = DataBinder.Eval(container.DataItem, columnName).ToString();
                //DataGridItem container = (DataGridItem)literal.NamingContainer;//就是找它的父控件，看Control源代码
                //literal.Text = DataBinder.Eval(container.DataItem, columnName).ToString();

            }
        } 

    
}