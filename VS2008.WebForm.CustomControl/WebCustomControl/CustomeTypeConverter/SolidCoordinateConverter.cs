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
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    ///  SolidCoordinate����Զ�������ת����
    /// </summary>
    public class SolidCoordinateConverter : TypeConverter
    {
        
        /// <summary>
        /// �ж��Ƿ��ܴ��ַ���ת��ΪSolidCoordinate��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// �ж��Ƿ��ܴ�SolidCoordinate��ת��Ϊstring��InstanceDescriptor����
        /// </summary>
        /// <param name="context"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }
      
        

        /// <summary>
        /// ���ַ���ת��ΪSolidCoordinate����
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
                throw new Exception("��ʽ����ȷ!");
            }
            return new SolidCoordinate(numArray[0], numArray[1], numArray[2]);
        }

        /// <summary>
        /// ��SolidCoordinate��ת��Ϊstring��InstanceDescriptor����
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
                throw new Exception("Ŀ�����Ͳ���Ϊ��!");
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
        /// ���������ĺ�ָ���������ֵ䴴��ʵ��
        /// </summary>
        /// <param name="context"></param>
        /// <param name="propertyValues"></param>
        /// <returns></returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new Exception("����ֵ����Ϊ��!");
            }
            object obj2 = propertyValues["X"];
            object obj3 = propertyValues["Y"];
            object obj4 = propertyValues["Z"];
            if (((obj2 == null) || (obj3 == null) || (obj4 == null)) || (!(obj2 is int) || !(obj3 is int) || !(obj4 is int)))
            {
                throw new Exception("��ʽ����ȷ!");
            }
            return new SolidCoordinate((int)obj2, (int)obj3, (int)obj4);
        }
      

        /// <summary>
        /// ������Ĵ˶����������Ҫ���� CreateInstance ��������ֵ����Ϊ true������Ϊ false
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }        
        

        /// <summary>
        /// ʹ��ָ���������ĺ�attributes����ָ���ɲ���valueָ���ļ�������
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
        /// ʹ��ָ���������ķ��ظö����Ƿ�֧������[���ָ��, ���Դ���Ҳ���ṩ��չ����ģʽ]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
