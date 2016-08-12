using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    /// <summary>
    ///  SolidCoordinate类的自定义类型转换器
    /// </summary>
    public class SolidCoordinateConverter : TypeConverter
    {
        
        /// <summary>
        /// 判断是否能从字符串转换为SolidCoordinate类
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// 判断是否能从SolidCoordinate类转换为string或InstanceDescriptor类型
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }
      
        

        /// <summary>
        /// 从字符串转换为SolidCoordinate类型
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string str = value as string;
            if (str == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            string str2 = str.Trim();
            if (str2.Length == 0)
            {
                return null;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            char ch = culture.TextInfo.ListSeparator[0];
            string[] strArray = str2.Split(new char[] { ch });
            int[] numArray = new int[strArray.Length];
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = (int)converter.ConvertFromString(context, culture, strArray[i]);
            }
            if (numArray.Length != 3)
            {
                throw new Exception("格式不正确!");
            }
            return new SolidCoordinate(numArray[0], numArray[1], numArray[2]);
        }

        /// <summary>
        /// 从SolidCoordinate类转换为string或InstanceDescriptor类型
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new Exception("目标类型不能为空!");
            }
            if (value is SolidCoordinate)
            {
                if (destinationType == typeof(string))
                {
                    SolidCoordinate solidCoordinate = (SolidCoordinate)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] strArray = new string[3];
                    int num = 0;
                    strArray[num++] = converter.ConvertToString(context, culture, solidCoordinate.X);
                    strArray[num++] = converter.ConvertToString(context, culture, solidCoordinate.Y);
                    strArray[num++] = converter.ConvertToString(context, culture, solidCoordinate.Z);
                    return string.Join(separator, strArray);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    SolidCoordinate solidCoordinate2 = (SolidCoordinate)value;
                    ConstructorInfo constructor = typeof(SolidCoordinate).GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int) });
                    if (constructor != null)
                    {
                        return new InstanceDescriptor(constructor, new object[] { solidCoordinate2.X, solidCoordinate2.Y, solidCoordinate2.Z });
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>
        /// 根据上下文和指定的属性字典创建实例
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propertyValues"></param>
        /// <returns></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new Exception("属性值不能为空!");
            }
            object obj2 = propertyValues["X"];
            object obj3 = propertyValues["Y"];
            object obj4 = propertyValues["Z"];
            if (((obj2 == null) || (obj3 == null) || (obj4 == null)) || (!(obj2 is int) || !(obj3 is int) || !(obj4 is int)))
            {
                throw new Exception("格式不正确!");
            }
            return new SolidCoordinate((int)obj2, (int)obj3, (int)obj4);
        }
      

        /// <summary>
        /// 如果更改此对象的属性需要调用 CreateInstance 来创建新值，则为 true；否则为 false
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }        
        

        /// <summary>
        /// 使用指定的上下文和attributes集合指定由参数value指定的集合数组
        /// </summary>
        /// <param name="context"></param>
        /// <param name="value"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(SolidCoordinate), attributes).Sort(new string[] { "X", "Y", "Z" });
        }     

        /// <summary>
        /// 使用指定的上下文返回该对象是否支持属性[如果指定, 属性窗口也会提供扩展输入模式]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
