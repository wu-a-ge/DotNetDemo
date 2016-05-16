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
                policy.Add("common.export.data.table","title_info");
                JObject articleType=new JObject();
                for (int i = 0; i < 10; i++)
                {
                    String chkName = "chk_" + i;
                    Control[]  results =tabTitlePage.Controls.Find(chkName, false);
                    if (results.Length > 0)
                    {
                        CheckBox chkInstance = (CheckBox) results[0];
                        //如果选择了所有，就忽略其它
                        if (chkInstance.Checked && chkInstance.Name.Equals("chk_0"))
                        {
                            articleType.Add("type",chkInstance.Tag.ToString());
                        }
                    }

                }
                
                policy.Add("common.export.data.ouput.format",11);
            
            }
            else
            {
                
                
            }
        }

        

       
    }
}
