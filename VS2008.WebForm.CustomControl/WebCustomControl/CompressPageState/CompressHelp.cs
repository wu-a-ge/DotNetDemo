using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;
using System.IO;
using System.Web.UI;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    public class CompressHelp
    {
        //序列化工具，LosFormatter是页面默认的序列器
        private static LosFormatter _formatter = new LosFormatter();
        /// <summary>
        /// 解压并反序列化状态内容
        /// </summary>
        /// <param name="stateString">从客户端取回的页面状态字符串</param>
        /// <returns>还原后的页面状态Pair对象</returns>
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
        /// 序列化并压缩状态内容
        /// </summary>
        /// <param name="state">页面状态</param>
        /// <returns>结果字符串</returns>
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
