using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

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
            JObject policy = new JObject();
            if (System.String.Compare(tabControl1.SelectedTab.Tag.ToString(), Title, System.StringComparison.Ordinal) == 0)
            {
                policy.Add("common.export.data.table", "title_info");

                 //type
                
                JObject articleType = new JObject();
                for (int i = 0; i < 10; i++)
                {
                    String chkName = "chk_" + i;
                    CheckBox chkInstance = (CheckBox)tabTitlePage.Controls.Find(chkName, false)[0];
                    //如果选择了所有，就忽略其它
                    if (chkInstance.Checked && chkInstance.Name.Equals("chk_0"))
                    {
                        articleType.Add(chkInstance.Tag.ToString(), txt_0.Text.Trim());
                        break;
                    }
                    else
                    {
                        TextBox value = (TextBox)tabTitlePage.Controls.Find("txt_" + chkInstance.Tag.ToString(), false)[0];
                        if (!String.IsNullOrEmpty(value.Text.Trim()))
                        articleType.Add(chkInstance.Tag.ToString(), value.Text.Trim());
                    }
                }
                policy.Add("common.export.data.article.type", articleType);

                
            }
            else
            {

                policy.Add("common.export.data.table", cbxTable.SelectedValue.ToString());
                policy.Add("common.export.data.fields", txtFields.Text.Trim());
            }
            //export format
            foreach (var childControl in groupExportFormat.Controls)
            {
                RadioButton tmpRadButton = childControl as RadioButton;
                if (tmpRadButton.Checked)
                {
                    policy.Add("common.export.data.output.format", tmpRadButton.Tag.ToString());
                    break;
                }

            }


            //export src
            foreach (var childControl in groupExportSrc.Controls)
            {
                RadioButton tmpRadButton = childControl as RadioButton;
                if (tmpRadButton.Checked)
                {
                    policy.Add("common.export.data.src", tmpRadButton.Tag.ToString());
                    break;
                }
            }
            policy.Add("common.export.data.find.value", txtIds.Text.Trim());
            policy.Add("common.export.data.rules", txtRules.Text.Trim());
            policy.Add("common.export.reduce.num", txtReduceNum.Text.Trim());
            policy.Add("common.export.reduce.mb", txtReduceMb.Text.Trim());
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter writer = new StreamWriter(File.Create("json.config", 2048), utf8);
            writer.WriteLine(policy.ToString(Formatting.None));
            writer.Close();
        }




    }
}
