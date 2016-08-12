using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.DynamicTemplateColumn
{
    public class ValidateEditField
    {
         private string column;
         public ValidateEditField(string column)
        {
            this.column = column;
        }

        public void InstantiateIn(Control container) 
        { 
            TextBox txtBox = new TextBox();
            txtBox.DataBinding += new EventHandler(txtBox_DataBinding); 
            container.Controls.Add(txtBox); 
            txtBox.ID = column; 

            RequiredFieldValidator valR = new RequiredFieldValidator(); 
            valR.Text = "Please Input"; 
            valR.ControlToValidate = txtBox.ID; 
            valR.Display = ValidatorDisplay.Dynamic; 
            valR.ID = "validate" + txtBox.ID; 
            container.Controls.Add(valR); 

        }

        void txtBox_DataBinding(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            GridViewRow container = (GridViewRow)txtBox.NamingContainer;
            txtBox.Text = DataBinder.Eval(container.DataItem,column).ToString(); 
        } 
    }
}