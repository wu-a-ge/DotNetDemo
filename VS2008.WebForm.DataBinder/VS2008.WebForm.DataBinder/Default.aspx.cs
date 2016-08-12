using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Demo
{
    public partial class Default : System.Web.UI.Page
    {
        public Artech.DataBinding.DataBinder DataBinder { get; private set; }
        public Customer GetCustomer()
        {
            return this.ViewState["__Customer"] as Customer;
        }
        public void SetCustomer(Customer customer)
        {
            this.ViewState["__Customer"] = customer;
        }
        public Default()
        {
            this.DataBinder = new Artech.DataBinding.DataBinder();
            this.DataBinder.DataItemBinding += (sender, args) =>
                {                  

                    if (args.BindingMapping.Control == this.Birthday)
                    {
                        args.BindingMapping.FormatString = "MM-dd-yyyy";
                    }
                };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            { return; }
            var customer = new Customer
            {
                ID = Guid.NewGuid().ToString(),
                FirstName = "Zhang",
                LastName = "San",
                Age = 30,
                Gender = "Male",
                BirthDay = new DateTime(1981, 8, 24),
                IsVip = true
            };
           this.SetCustomer(customer);
        }

        protected void ButtonBind_Click(object sender, EventArgs e)
        {
            this.DataBinder.BindData(this.GetCustomer(), this,null);
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            object customer = this.GetCustomer();
            this.DataBinder.UpdateData(customer, this, null);
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.DataBinder.BindData(new Customer(), this, null);
        }
    }
}