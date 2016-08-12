using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [DefaultProperty("SelectFood")]
    [ToolboxData("<{0}:CustomCollectionPropertyConverterControl runat=server></{0}:CustomCollectionPropertyConverterControl>")]
    public class CustomCollectionPropertyConverterControl : WebControl
    {
        private string strSelectFood;
        [Bindable(true)]
        [Category("���")]                
        [Description("ѡ��ʳƷ���")]
        [TypeConverter(typeof(CustomCollectionPropertyConverter))]
        public string SelectFood
        {
            get
            {
                return strSelectFood;
            }

            set
            {
                strSelectFood = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("�ؼ�����ʾ��, ���:���������<=>������ͼ���� �л��鿴Ч��.");
        }
    }
}
