using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DelPDFShuiYing
{
    class Program
    {
        private const string FindString = "%%EOF";
        private const int LenShuiYing = 3259;
        static void Main(string[] args)
        {

            using (BufferedStream rBufferStream = new BufferedStream(File.Open("test.pdf", FileMode.Open)))
            {

                rBufferStream.SetLength(rBufferStream.Length - LenShuiYing);
                //byte[] buffers = new byte[5];
                //long currenPos = 0;
                //int i = 0;
                //try
                //{
                //    while (true)
                //    {

                //        rBufferStream.Seek(100, SeekOrigin.End);
                //        int len = rBufferStream.Read(buffers, 0, 5);
                //        if (0 != len)
                //        {
                //            string result = Encoding.UTF8.GetString(buffers);

                //            //找到了
                //            if (FindString == result)
                //            {
                //                //保存位置
                //                currenPos = rBufferStream.Position;
                //                break;
                //            }
                //        }
                //        i++;
                //    }
                //    rBufferStream.SetLength(currenPos);
                //}
                //catch (IOException e)
                //{
                //    return;
                //}
            
            }
           

        }
    }
}
