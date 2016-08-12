using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class SiteFilter:Stream
    {

            Stream responseStream;
            long position;
            StringBuilder responseHtml;
            /// <summary>
            /// 当原始数据采集成功后激发。
            /// </summary>
            //public event EventHandler<RawDataEventArgs> OnRawDataRecordedEvent;

            public SiteFilter(Stream inputStream)
            {
                responseStream = inputStream;
                responseHtml = new StringBuilder();
            }
            //实现Stream 虚方法
            public override bool CanRead
            {
                get
                {
                    return true;
                }
            }
            public override bool CanSeek
            {
                get
                {
                    return true;
                }
            }
            public override bool CanWrite
            {
                get
                {
                    return true;
                }
            }
            public override void Close()
            {
                responseStream.Close();
            }

            public override void Flush()
            {
                responseStream.Flush();
            }

            public override long Length
            {
                get
                {
                    return 0;
                }
            }
            public override long Position
            {
                get
                {
                    return position;
                }
                set
                {
                    position = value;
                }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return responseStream.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return responseStream.Seek(offset, origin);
            }

            public override void SetLength(long length)
            {
                responseStream.SetLength(length);
            }
            //关键的点，在HttpResponse 输入内容的时候，一定会调用此方法输入数据，所以要在此方法内截获数据
            public override void Write(byte[] buffer, int offset, int count)
            {
                string strBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);

                //采用正则，检查输入的是否有页面结束符</html>
                Regex eof = new Regex("</html>", RegexOptions.IgnoreCase);
                //输出时如果一次输出不完就分块输出，所以这里要进行判断！
                if (!eof.IsMatch(strBuffer))
                {
                    //页面没有输出完毕，继续追加内容
                    responseHtml.Append(strBuffer);
                }
                else
                {
                    //页面输出已经完毕，截获内容
                    responseHtml.Append(strBuffer);

                    responseHtml.Append("<div>全站的页面输出都会经过我来处理！</div>");
                    string finalHtml = responseHtml.ToString();
                    ////激发数据已经获取事件
                    //OnRawDataRecordedEvent(this, new RawDataEventArgs(finalHtml));

                    //继续传递要发出的内容写入流
                    byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(finalHtml);

                    responseStream.Write(data, 0, data.Length);
                }
            }
        
    }
}