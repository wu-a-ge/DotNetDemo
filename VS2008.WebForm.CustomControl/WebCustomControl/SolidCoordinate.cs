using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [TypeConverter(typeof(SolidCoordinateConverter))]
    public class SolidCoordinate
    {
        private int x;
        private int y;
        private int z;

        public SolidCoordinate()
        {        
        } 

        public SolidCoordinate(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        [NotifyParentProperty(true)]
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        [NotifyParentProperty(true)]
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        [NotifyParentProperty(true)]
        public int Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }
    }
}
