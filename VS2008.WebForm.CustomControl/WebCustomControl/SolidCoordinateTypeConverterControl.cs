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
    [DefaultProperty("SolidCoordinate")]
    [ToolboxData("<{0}:SolidCoordinateTypeConverterControl runat=server></{0}:SolidCoordinateTypeConverterControl>")]
    public class SolidCoordinateTypeConverterControl : WebControl
    {
        SolidCoordinate solidCoordinate;
        [Category("ת����")]
        [Description("SolidCoordinate��������(��������ֵ����չ����)")]        
        public SolidCoordinate SolidCoordinate
        {
            get
            {
                if (solidCoordinate == null)
                {
                    solidCoordinate = new SolidCoordinate();
                }
                return solidCoordinate;
            }
            set
            {
                solidCoordinate = value;
            }
 
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("�ؼ�����ʾ��, ���:���������<=>������ͼ���� �л��鿴Ч��.");
        }
    }
}
