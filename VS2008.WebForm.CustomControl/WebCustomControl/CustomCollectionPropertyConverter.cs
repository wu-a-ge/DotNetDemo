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
    public class CustomCollectionPropertyConverter : StringConverter
    {
        /// <summary>
        ///  根据上下文件参数返回是否支持从列表中选取标准值集
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }  
                
        /// <summary>
        ///  返回标准值的集合是否为独占列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;     //针对StringConverter有效, 如果是TypeConverter, 即相当于恒为独占列表[属性值不允许输入]
        }
        
        /// <summary>
        ///  取得集合列表值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] strArray = new string[] { "水果", "蔬菜", "肉食", "面食", "蛋类" };
            StandardValuesCollection returnStandardValuesCollection = new StandardValuesCollection(strArray);
            return returnStandardValuesCollection;
        }                
    }
}
