using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [ToolboxData("<{0}:CalculatorControl runat=server></{0}:CalculatorControl>")]
    public class CalculatorControl : CompositeControl
    {
        //������
        private TextBox tb1;
        private TextBox tb2;

        //��ʾ���
        private Label lb;

        //����(+-*/)
        private Button bt1;
        private Button bt2;
        private Button bt3;
        private Button bt4;

        private const string ResultText = "����б�: ";
        private Unit ButtonWidth = Unit.Pixel(30);

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            tb1 = new TextBox();
            tb1.ID = "TextBox1";
            this.Controls.Add(tb1);

            tb2 = new TextBox();
            tb2.ID = "TextBox2";
            this.Controls.Add(tb2);

            lb = new Label();
            lb.ID = "Label1";

            lb.Text = ResultText;
            this.Controls.Add(lb);

            bt1 = new Button();
            bt1.ID = "Button1";
            bt1.Width = ButtonWidth;
            bt1.Text = "+";            
            bt1.CommandArgument = "+";
            bt1.Click += new EventHandler(bt_Click);
            this.Controls.Add(bt1);
            bt2 = new Button();
            bt2.ID = "Button2";
            bt2.Width = ButtonWidth;
            bt2.Text = "-";
            bt2.CommandArgument = "-";
            bt2.Click += new EventHandler(bt_Click);
            this.Controls.Add(bt2);
            bt3 = new Button();
            bt3.ID = "Button3";
            bt3.Width = ButtonWidth;
            bt3.Text = "*";
            bt3.CommandArgument = "*";
            bt3.Click += new EventHandler(bt_Click);
            this.Controls.Add(bt3);
            bt4 = new Button();
            bt4.ID = "Button4";
            bt4.Width = ButtonWidth;
            bt4.Text = "/";
            bt4.CommandArgument = "/";
            bt4.Click += new EventHandler(bt_Click);
            this.Controls.Add(bt4);
            this.ChildControlsCreated = true;
        }

        void bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResultText != lb.Text)
                {
                    lb.Text = lb.Text + ", ";
                }
                switch (((Button)sender).CommandArgument)
                {
                    case "+": lb.Text = lb.Text + Convert.ToString(Convert.ToInt32(this.tb1.Text) + Convert.ToInt32(this.tb2.Text)); break;
                    case "-": lb.Text = lb.Text + Convert.ToString(Convert.ToInt32(this.tb1.Text) - Convert.ToInt32(this.tb2.Text)); break;
                    case "*": lb.Text = lb.Text + Convert.ToString(Convert.ToInt32(this.tb1.Text) * Convert.ToInt32(this.tb2.Text)); break;
                    case "/": lb.Text = lb.Text + Convert.ToString(Convert.ToInt32(this.tb1.Text) / Convert.ToInt32(this.tb2.Text)); break;
                }
            }
            catch
            {
                lb.Text = "It's is not right format, please input again.";
            }
        }       

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Style, "padding: 10; background-color: #C0C0FE; font-size: 12px; width:180px; height: 160; vertical-align: top; text-align: center;");            
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Valign, "middle");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            //Operating item 1
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            tb1.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            //<br>
            writer.WriteBreak();

            //Operating symbol
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.WriteEncodedText(" + - * / ");
            writer.RenderEndTag();
            writer.RenderEndTag();

            //Operating item2
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            tb2.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            //Operating symbol
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.WriteEncodedText(" EQUAL ");
            writer.RenderEndTag();
            writer.RenderEndTag();

            //The relust label
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Align, "left");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            lb.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            //Button1
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Nobr);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            bt1.RenderControl(writer);
            bt2.RenderControl(writer);
            bt3.RenderControl(writer);
            bt4.RenderControl(writer);
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "10px");
            writer.RenderBeginTag(HtmlTextWriterTag.Td);            
            writer.RenderEndTag();
            writer.RenderEndTag();

            writer.RenderEndTag();

            writer.RenderEndTag();
            base.Render(writer);
        }
    }
}
