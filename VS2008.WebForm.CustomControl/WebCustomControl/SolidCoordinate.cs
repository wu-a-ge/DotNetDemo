using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WebCustomControl
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
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
