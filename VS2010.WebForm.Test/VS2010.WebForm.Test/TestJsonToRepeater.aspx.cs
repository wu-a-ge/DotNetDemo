using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
namespace VS2010.WebForm.Test
{
    public partial class TestJsonToRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JObject o = JObject.Parse(@"{
  ""Stores"": [
    ""Lambton Quay"",
    ""Willis Street""
  ],
  ""Manufacturers"": [
    {
      ""Name"": ""Acme Co"",
      ""Products"": [
        {
          ""Name"": ""Anvil"",
          ""Price"": 50
        }
      ]
    },
    {
      ""Name"": ""Contoso"",
      ""Products"": [
        {
          ""Name"": ""Elbow Grease"",
          ""Price"": 99.95
        },
        {
          ""Name"": ""Headlight Fluid"",
          ""Price"": 4
        }
      ]
    }
  ]
}");
              

            }
        }
    }
}