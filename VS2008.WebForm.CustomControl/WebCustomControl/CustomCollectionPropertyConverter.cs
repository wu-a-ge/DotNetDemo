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
    public class CustomCollectionPropertyConverter : StringConverter
    {
        /// <summary>
        ///  ���������ļ����������Ƿ�֧�ִ��б���ѡȡ��׼ֵ��
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }  
                
        /// <summary>
        ///  ���ر�׼ֵ�ļ����Ƿ�Ϊ��ռ�б�
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;     //���StringConverter��Ч, �����TypeConverter, ���൱�ں�Ϊ��ռ�б�[����ֵ����������]
        }
        
        /// <summary>
        ///  ȡ�ü����б�ֵ
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] strArray = new string[] { "ˮ��", "�߲�", "��ʳ", "��ʳ", "����" };
            StandardValuesCollection returnStandardValuesCollection = new StandardValuesCollection(strArray);
            return returnStandardValuesCollection;
        }                
    }
}
