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
    [ToolboxData("<{0}:ViewStateTypeConverter runat=server></{0}:ViewStateTypeConverter>")]
    public class ViewStateTypeConverter : WebControl
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

        protected override object SaveViewState()
        {
            Pair p = new Pair();
            p.First = base.SaveViewState();
            //SolidCoordinateConverter convert = new SolidCoordinateConverter();
            TypeConverter convert = TypeDescriptor.GetConverter(this.SolidCoordinate);
            p.Second = convert.ConvertTo(null, null, this.SolidCoordinate, typeof(string));
            for (int i = 0; i < 2; i++)
            {
                if (p.First != null || p.Second != null)
                {
                    return p;
                }
            }
            return null;
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
            {
                base.LoadViewState(null);
                return;
            }
            else
            {
                Pair p = (Pair)savedState;
                if (p == null)
                {
                    throw new ArgumentException("��Ч�� View State ����!");
                }
                base.LoadViewState(p.First);
                if (p.Second != null)
                {
                    //SolidCoordinateConverter convert = new SolidCoordinateConverter();
                    TypeConverter convert = TypeDescriptor.GetConverter(this.SolidCoordinate);
                    this.SolidCoordinate = convert.ConvertFrom(null, null, p.Second) as SolidCoordinate;
                }
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("����ͼ״̬��Ӧ������ת�����ؼ�");
        }
    }
}
