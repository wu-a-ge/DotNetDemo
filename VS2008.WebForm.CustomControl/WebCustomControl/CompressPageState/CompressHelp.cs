using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Web.UI;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    public class CompressHelp
    {
        //���л����ߣ�LosFormatter��ҳ��Ĭ�ϵ�������
        private static LosFormatter _formatter = new LosFormatter();
        /// <summary>
        /// ��ѹ�������л�״̬����
        /// </summary>
        /// <param name="stateString">�ӿͻ���ȡ�ص�ҳ��״̬�ַ���</param>
        /// <returns>��ԭ���ҳ��״̬Pair����</returns>
        public static object Decompress(string stateString)
        {
            byte[] buffer = Convert.FromBase64String(stateString);
            MemoryStream ms = new MemoryStream(buffer);
            GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream msReader = new MemoryStream();
            buffer = new byte[0x1000];
            while (true)
            {
                int read = zipStream.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                {
                    break;
                }
                msReader.Write(buffer, 0, read);
            }
            zipStream.Close();
            ms.Close();
            msReader.Position = 0;
            buffer = msReader.ToArray();
            stateString = Convert.ToBase64String(buffer);
            return _formatter.Deserialize(stateString);
        }
        /// <summary>
        /// ���л���ѹ��״̬����
        /// </summary>
        /// <param name="state">ҳ��״̬</param>
        /// <returns>����ַ���</returns>
        public static string Compress(object state)
        {
            StringWriter writer = new StringWriter();
            _formatter.Serialize(writer, state);
            string stateString = writer.ToString();
            writer.Close();
            byte[] buffer = Convert.FromBase64String(stateString);
            MemoryStream ms = new MemoryStream();
            GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress, true);
            zipStream.Write(buffer, 0, buffer.Length);
            zipStream.Close();
            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
            ms.Close();
            stateString = Convert.ToBase64String(buffer);
            return stateString;
        }
    }
}
