using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace DataExportConfiguration
{
    public partial class Form1 : Form
    {
        private const String Title = "title_info";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            JObject policy=new JObject();
            if (System.String.Compare(tabControl1.SelectedTab.Tag.ToString(), Title, System.StringComparison.Ordinal) == 0)
            {
                policy.Add("common.export.table","title_info");
              
                policy.Add("common.export.ouput.format",11);
            
            }
        }

        

       
    }
}
